using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Businness.Services.Interfaces;
using Shop.Core.Entities.Models;
using Shop.DTO.UserDTO;
using Microsoft.EntityFrameworkCore;

namespace MyShopping.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(IAccountService accountService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _accountService = accountService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Register endpoint (User Registration)
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto, [FromQuery] string role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _accountService.SignUp(dto, role);
            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(new { message = "Please verify your email" });
        }

        // Login endpoint (User Login)
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _accountService.Login(dto, false);
            if (!result.Success)
            {
                return Unauthorized(new { message = result.Message });
            }

            return Ok(new { message = "Login successfully" });
        }

        // Logout endpoint
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            var result = await _accountService.LogOut();
            return Ok(new { message = "Logged out successfully" });
        }

        // Forget Password endpoint
        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword([FromBody] string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest(new { message = "Please provide email!" });
            }

            var result = await _accountService.ForgetPassword(email);
            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(new { message = "Password reset email sent" });
        }

        // Reset Password (Get the reset password form)
        [HttpGet("reset-password")]
        public async Task<IActionResult> ResetPasswordGet([FromQuery] string email, [FromQuery] string token)
        {
            var result = await _accountService.ResetPasswordGet(email, token);
            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(result.Data);
        }

        // Reset Password (Submit new password)
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordPost([FromBody] ResetPasswordDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _accountService.ResetPasswordPost(dto);
            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(new { message = "Password reset successfully" });
        }

        // Register with Google (Initiates Google OAuth flow)
        [HttpGet("register-with-google")]
        public async Task<IActionResult> RegisterWithGoogle([FromQuery] string returnUrl = null)
        {
            var result = await _accountService.RegisterWithGoogle(returnUrl);
            if (result.Success)
            {
                return Ok(new { message = "Google authentication initiated" });
            }

            return BadRequest(new { message = result.Message });
        }

        // Google Callback (Handle the Google OAuth callback)
        [HttpGet("google-callback")]
        public async Task<IActionResult> GoogleCallback([FromQuery] string returnUrl = null)
        {
            var result = await _accountService.GoogleCallback(returnUrl);
            if (result.Success)
            {
                return Ok(new { message = "Google authentication successful" });
            }

            return BadRequest(new { message = result.Message });
        }

        // Update User Information (Optional: You can modify as per need)
        [HttpPut("update")]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _accountService.Update(dto);
            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(new { message = "User updated successfully" });
        }
    }

}
