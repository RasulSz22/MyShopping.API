using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using NETCore.MailKit.Core;
using Shop.Businness.Responses;
using Shop.Businness.Services.Interfaces;
using Shop.Core.Entities.Models;
using Shop.Core.Helper.MailHelper;
using Shop.Core.Utilities.Results.Abstract;
using Shop.Core.Utilities.Results.Concrete.ErrorResults;
using Shop.Core.Utilities.Results.Concrete.SuccessResults;
using Shop.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Shop.Core.Utilities.Results.Abstract.IResult;

namespace Shop.Businness.Services.Implementations
{
    public class AccountService : IAccountService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHttpContextAccessor _http;
        private readonly IEmailHelper _emailService;
        private readonly IUrlHelper _urlHelper;

        public AccountService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, IHttpContextAccessor http, IEmailHelper emailService, IUrlHelper urlHelper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _http = http;
            _emailService = emailService;
            _urlHelper = urlHelper;
        }

        public async Task<bool> ChangeRole(string userId, string newRoleId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            if (currentRoles == null || currentRoles.Count == 0)
            {
                return false;
            }

            var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!removeResult.Succeeded)
            {
                return false;
            }
            var addResult = await _userManager.AddToRoleAsync(user, newRoleId);
            return addResult.Succeeded;
        }

        public async Task<IResult> ForgetPassword(string email)
        {
            if (email is null)
            {
                return new ErrorResult("Please Enter Email!");
            }

            var isValidEmail = _emailService.IsValidEmail(email);
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return new ErrorResult("Email is not registered!");
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (token is null) return new ErrorResult("Token is not generated");
            var urlHelperFactory = _http.HttpContext.RequestServices.GetService<IUrlHelperFactory>();
            if (urlHelperFactory != null)
            {
                var endpoint = _http.HttpContext.GetEndpoint();
                if (endpoint != null)
                {
                    var actionDesciptor = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();
                    if (actionDesciptor != null)
                    {
                        var actionContext = new ActionContext(_http.HttpContext, _http.HttpContext.GetRouteData(), actionDesciptor);
                        var urlHelper = urlHelperFactory.GetUrlHelper(actionContext);
                        var url = urlHelper.Action("Reset Password", "Account", new { email = user.Email, token = token }, protocol: _http.HttpContext.Request.Scheme);
                        await _emailService.SendEmailAsync(user.Email, url, "Verify Email for resetpassword", token);
                    }
                }
            }
            return new SuccessResult();
        }

        public async Task<PagginatedResponse<AppUser>> GetAllAdmin(int count, int page)
        {
            try
            {
                IQueryable<AppUser> query = _userManager.Users;
                if (count > 0 && page > 0)
                {
                    var usersInRoles = new List<AppUser>();
                    foreach (var user in query)
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        foreach (var role in roles)
                        {
                            if (role == "Admin")
                            {
                                usersInRoles.Add(user);
                            }
                        }
                    }
                    query = usersInRoles.AsQueryable();
                }
                int totalCount = query.Count();
                List<AppUser> users = query.Skip((page - 1) * count).Take(count).ToList();
                var response = new PagginatedResponse<AppUser>(
                    datas: users,
                    pageNumber: page,
                    pageSize: count,
                    totalCount: totalCount,
                    otherdatas: null
                    );
                return response;
            }
            catch (Exception ex)
            {
                return new PagginatedResponse<AppUser>(
                    datas: null,
                    pageNumber: 0,
                    pageSize: 0,
                    totalCount: 0,
                    otherdatas: null
                    );
            }
        }

        public async Task<PagginatedResponse<AppUser>> GetAllUsers(int count, int page)
        {
            try
            {
                IQueryable<AppUser> query = _userManager.Users;

                if (count > 0 && page > 0)
                {
                    var usersInRoles = new List<AppUser>();
                    foreach (var user in query)
                    {
                        var roles = await _userManager.GetRolesAsync(user);

                        foreach (var role in roles)
                        {
                            if (role == "Admin" || role == "Customer")
                            {
                                usersInRoles.Add(user);
                            }
                        }

                    }
                    query = usersInRoles.AsQueryable();
                }
                int totalCount = query.Count();
                List<AppUser> users = query.Skip((page - 1) * count).Take(count).ToList();
                var response = new PagginatedResponse<AppUser>(
                    datas: users,
                    pageNumber: page,
                    pageSize: count,
                    totalCount: totalCount,
                    otherdatas: null
                );
                return response;
            }
            catch (Exception ex)
            {
                return new PagginatedResponse<AppUser>(
                    datas: null,
                    pageNumber: 0,
                    pageSize: 0,
                    totalCount: 0,
                    otherdatas: null
                );
            }
        }

        public async Task<IDataResult<ResetPasswordDTO>> GetResetPassword(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                return new ErrorDataResult<ResetPasswordDTO>("User not found");
            }
            ResetPasswordDTO dto = new ResetPasswordDTO()
            {
                Email = email,
                Token = token
            };

            return new SuccessDataResult<ResetPasswordDTO>(dto, "get resetPassword");
        }

        public async Task<AppUser> GetUser(string id)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(u => u.Id == id);
        }

        private async Task<bool> IsUserInRole(AppUser user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<IResult> Login(LoginDTO dto, bool IsAdminPanel)
        {
            try
            {
                AppUser checkUser = await _userManager.FindByNameAsync(dto.UsernameOrEmail);

                if (checkUser == null)
                {
                    checkUser = await _userManager.FindByEmailAsync(dto.UsernameOrEmail);
                }

                if (checkUser == null)
                    return new ErrorResult("User not Found!");

                if (!checkUser.EmailConfirmed)
                    return new ErrorResult("Please verify this email before sign in!");

                if (!checkUser.IsActive)
                    return new ErrorResult("Your account is blocked! Please contact the administrator.");

                if ((IsAdminPanel && (await IsUserInRole(checkUser, "Admin") || await IsUserInRole(checkUser, "Customer"))))
                {
                    return new ErrorResult(IsAdminPanel ? "You are not authorized to access the admin panel." : "You are not authorized to access the user panel. Please create a user for yourself.");
                }

                var result = await _signInManager.PasswordSignInAsync(checkUser, dto.Password, dto.RememberMe, true);

                if (!result.Succeeded)
                    return new ErrorResult("Email or Password is incorrect!");

                if (result.IsLockedOut)
                    return new ErrorResult("User is locked out!");

                if (result.IsNotAllowed)
                    return new ErrorResult("User is not allowed to sign in!");

                return new SuccessResult("Login Successfully");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return new SuccessResult();
            }

            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> ResetPasswordPost(ResetPasswordDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return new ErrorResult("User not Found!");
            }

            var result = await _userManager.ResetPasswordAsync(user, dto.Token, dto.Password);
            if (!result.Succeeded)
            {
                string errors = string.Join("\n", result.Errors.Select(error => error.Description));
                return new ErrorResult("Reset password failed: " + errors);
            }

            return new SuccessResult("Reset password success");
        }

        public async Task<IDataResult<string>> SignUp(RegisterDTO dto, string role)
        {
            var isValidEmail = _emailService.IsValidEmail(dto.Email);
            if (!isValidEmail) return new ErrorDataResult<string>(message: "Invalid Email!");
            var chekUser = await _userManager.FindByEmailAsync(dto.Email);
            if (chekUser != null) return new ErrorDataResult<string>(message: "Email is already used!");
            AppUser appUser = new AppUser()
            {
                UserName = dto.Username,
                Email = dto.Email,
                IsActive = true,
            };
            var result = await _userManager.CreateAsync(appUser, dto.Password);
            if (!result.Succeeded) return new ErrorDataResult<string>(message: string.Join('\n', result.Errors.Select(x => x.Description)));
            var hasUserRole = await _userManager.IsInRoleAsync(appUser, role);
            if (!hasUserRole) await _userManager.AddToRoleAsync(appUser, role);
            return new SuccessDataResult<string>(
                message: "RegisterDto successfull!"
                );
        }

        public async Task<IResult> Update(UpdateDTO dto)
        {
            var user = await _userManager.FindByNameAsync(_http.HttpContext.User.Identity.Name);
            if (user == null)
            {
                return new ErrorResult("User not found!");
            }

            if (!string.IsNullOrEmpty(dto.UserName))
            {
                user.UserName = dto.UserName;
            }

            if (!string.IsNullOrEmpty(dto.OldPassword) && !string.IsNullOrEmpty(dto.NewPassword))
            {
                var changePasswordResult = await _userManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);
                if (!changePasswordResult.Succeeded)
                {
                    string errors = string.Join("\n", changePasswordResult.Errors.Select(error => error.Description));
                    return new ErrorResult(errors);
                }
            }

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                string errors = string.Join("\n", result.Errors.Select(error => error.Description));
                return new ErrorResult(errors);
            }

            await _signInManager.RefreshSignInAsync(user);

            return new SuccessResult("User updated successfully");
        }

        public async Task<IResult> VerifyEmail(string token, string email)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(email);
            if (appUser == null) return new ErrorResult("User Not Found");
            var res = await _userManager.ConfirmEmailAsync(appUser, token);
            if (!res.Succeeded)
            {
                var errors = string.Join(",", res.Errors.Select(e => e.Description));
                return new ErrorResult($"Confirm Email is Invalid : {errors}");
            }
            appUser.EmailConfirmed = true;
            await _signInManager.SignInAsync(appUser, true);
            return new SuccessResult("Email Accepted and Signed In");
        }
    }
}
