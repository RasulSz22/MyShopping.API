using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Businness.Services.Interfaces;
using Shop.Core.Entities.Models;
using Shop.DTO.UserDTO;

namespace MyShopping.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AccountController(
            IAccountService accountService,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IWebHostEnvironment webHostEnvironment)
        {
            _accountService = accountService;
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto, [FromQuery] string role)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _accountService.SignUp(dto, role);
            if (!res.Success)
                return BadRequest(new { res.Message });

            return Ok(new { Message = "Please verify your email." });
        }

        [HttpGet("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromQuery] string token, [FromQuery] string email)
        {
            var result = await _accountService.VerifyEmail(token, email);
            if (!result.Success)
                return BadRequest(new { result.Message });

            return Ok(new { Message = "Successfully signed up." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _accountService.Login(dto, false);
            if (!result.Success)
                return Unauthorized(new { result.Message });

            return Ok(new { Message = "Login successful." });
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _accountService.Logout();
            return Ok(new { Message = "Logged out successfully." });
        }

        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword([FromBody] string email)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _accountService.ForgetPassword(email);
            if (!result.Success)
                return BadRequest(new { result.Message });

            return Ok(new { Message = "Password reset link sent to your email." });
        }

        [HttpGet("reset-password")]
        public async Task<IActionResult> ResetPassword([FromQuery] string email, [FromQuery] string token)
        {
            var result = await _accountService.GetResetPassword(email, token);
            if (!result.Success)
                return BadRequest(new { result.Message });

            return Ok(result.Data);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _accountService.ResetPasswordPost(dto);
            if (!result.Success)
                return BadRequest(new { result.Message });

            return Ok(new { Message = "Password reset successfully." });
        }
    }


}
