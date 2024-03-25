using Equipments.Identity.Models;
using Equipments.Identity.Services.EmailSender;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Identity.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;
        private readonly IEmailSender _emailSender;

        public AuthController(UserManager<AppUser> userManager, IConfiguration configuration, ILogger<AuthController> logger, IEmailSender emailSender)
        {
            _userManager = userManager;
            _configuration = configuration;
            _logger = logger;
            _emailSender = emailSender;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new AppUser()
            {
                UserName = model.Username,
                Email = model.Email,
                RegistrationDate = DateTime.UtcNow,
                EmailConfirmationCode = AppUser.GenerateEmailConfirmationCode(),
                IsAdmin = false
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest("Не удалось зарегистрировать пользователя");
            }

            var resultClaim = await _userManager.AddClaimsAsync(user, new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.IsAdmin ? "admin" : "user")
            });
            if (!resultClaim.Succeeded)
            {
                return BadRequest("Не удалось создать претензии");
            }

            await _emailSender.SendEmailAsync(
                user.Email,
                "Подтверждение электронной почты",
                user.EmailConfirmationCode);

            return Ok();
        }
        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new AppUser()
            {
                UserName = model.Username,
                Email = model.Email,
                IsAdmin = true
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest("Не удалось зарегистрировать пользователя");
            }
            var resultRole = await _userManager.AddToRoleAsync(user, user.IsAdmin ? "admin" : "user");
            if (resultRole.Succeeded)
            {
                var resultClaim = await _userManager.AddClaimsAsync(user, new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, _userManager.GetRolesAsync(user).Result.First())
                });
                if (!resultClaim.Succeeded)
                {
                    return BadRequest("Не удалось создать претензии");
                }
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost("confirm-email")]
        public async Task<ActionResult> Confirm(ConfirmEmailModel model)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(user => user.EmailConfirmationCode == model.Code && user.EmailConfirmed == false);

            if (user == null)
            {
                return BadRequest("Неправильный код");
            }

            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);

            return Ok();

        }
        [HttpPost("resend-email-code")]
        public async Task<ActionResult> ResendEmailCode(ResendEmailCodeModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("Пользователь не найден");
            }
            if (user.EmailConfirmed)
            {
                return BadRequest("Электронная почта подтверждена");
            }

            user.EmailConfirmationCode = AppUser.GenerateEmailConfirmationCode();
            await _userManager.UpdateAsync(user);

            await _emailSender.SendEmailAsync(
                user.Email,
                "Подтверждение электронной почты",
                user.EmailConfirmationCode);

            return Ok();
        }

    }
}
