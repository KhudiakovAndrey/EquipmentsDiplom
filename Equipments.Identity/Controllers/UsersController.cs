using Equipments.Identity.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Equipments.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public UsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<UserDto>> GetMeInfo()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            string id = identity.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var user = await _userManager.Users.FirstOrDefaultAsync(user => user.Id == id);

            var userDto = new UserDto
            {
                ID = Guid.Parse(user.Id),
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
            return Ok(userDto);
        }
    }
}
