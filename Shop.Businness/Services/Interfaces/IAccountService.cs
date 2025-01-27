﻿using Shop.Businness.Responses;
using Shop.Core.Entities.Models;
using Shop.Core.Utilities.Results.Abstract;
using Shop.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Businness.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<IDataResult<string>> SignUp(RegisterDTO dto, string role);
        public Task<IResult> VerifyEmail(string token, string email);
        public Task<IResult> Login(LoginDTO dto, bool IsAdminPanel);
        public Task<IResult> Logout();
        public Task<IResult> ForgetPassword(string email);
        public Task<IDataResult<ResetPasswordDTO>> GetResetPassword(string email, string token);
        public Task<IResult> ResetPasswordPost(ResetPasswordDTO dto);
        public Task<IResult> Update(UpdateDTO dto);
        public Task<PagginatedResponse<AppUser>> GetAllUsers(int count, int page);
        public Task<PagginatedResponse<AppUser>> GetAllAdmin(int count, int page);
        public Task<AppUser> GetUser(string id);
        public Task<bool> ChangeRole(string userId, string newRoleId);
    }
}
