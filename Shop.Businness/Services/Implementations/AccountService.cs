using Shop.Businness.Responses;
using Shop.Businness.Services.Interfaces;
using Shop.Core.Entities.Models;
using Shop.Core.Utilities.Results.Abstract;
using Shop.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Businness.Services.Implementations
{
    public class AccountService : IAccountService
    {


        public async Task<bool> ChangeRole(string userId, string newRoleId)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> ChangeUserActivationStatus(string email, bool activate)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> ForgetPassword(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<PagginatedResponse<AppUser>> GetAllAdmin(int count, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<PagginatedResponse<AppUser>> GetAllUsers(int count, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<ResetPasswordDTO>> GetResetPassword(string email, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<AppUser> GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> GoogleCallback(string returnUrl = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> Login(LoginDTO dto, bool IsAdminPanel)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> RegisterWithGoogle(string returnUrl = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> ResetPasswordPost(ResetPasswordDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<string>> SignUp(RegisterDTO dto, string role)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> Update(UpdateDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> VerifyEmail(string token, string email)
        {
            throw new NotImplementedException();
        }
    }
}
