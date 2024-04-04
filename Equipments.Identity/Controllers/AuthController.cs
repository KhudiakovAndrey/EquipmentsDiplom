using Equipments.Api;
using Equipments.Identity.Models;
using Equipments.Identity.Services.EmailSender;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<AppUser> userManager,
                                IEmailSender emailSender,
                                SignInManager<AppUser> signInManager,
                                IConfiguration configuration)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponse("Объект не прошёл проверку данных"));
            }

            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null && !user.EmailConfirmed)
                {
                    var errorResponse = new ErrorResponse(ErrorCodes.email_not_confirmed, user.Email);
                    return BadRequest(errorResponse);
                }
                if (user != null && user.LockoutEnabled)
                {
                    var errorResponse = new ErrorResponse(ErrorCodes.account_locked, $"Учётная запись заблокирована до {user?.LockoutEnd.Value.ToString("dd.MM.yyyy")}");
                    return BadRequest(errorResponse);
                }
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user!.Id),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.UtcNow.AddSeconds(Convert.ToDouble(_configuration["Jwt:ExpireDays"]));

                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: expires,
                    signingCredentials: creds
                    );
                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = expires
                    });
            }

            return BadRequest(new ErrorResponse("Неправильный логин или пароль"));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponse("Объект не прошёл проверку данных"));
            }

            var findByLoginUser = await _userManager.FindByNameAsync(model.Username);
            var findByEmailUser = await _userManager.FindByEmailAsync(model.Email);

            if (findByEmailUser != null || findByLoginUser != null)
            {
                string errorLogin = findByLoginUser != null ? "Пользователь с таким логином уже существует" : string.Empty;
                string errorEmail = findByEmailUser != null ? "Пользователь с таким емайлом уже существует" : string.Empty;
                return BadRequest(new ErrorResponse(errorLogin + "\n" + errorEmail));
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
                return BadRequest(new ErrorResponse("Не удалось зарегистрировать пользователя"));
            }

            var resultClaim = await _userManager.AddClaimsAsync(user, new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.IsAdmin ? "admin" : "user")
            });
            if (!resultClaim.Succeeded)
            {
                return BadRequest(new ErrorResponse("Не удалось создать претензии"));
            }

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
                return BadRequest(new ErrorResponse("Пользователь не найден"));
            }
            if (user.EmailConfirmed)
            {
                return BadRequest(new ErrorResponse("Электронная почта подтверждена"));
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
