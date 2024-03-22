using Equipments.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class UserController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<UserController> _logger;

        public UserController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ILogger<UserController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
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

    }
}
