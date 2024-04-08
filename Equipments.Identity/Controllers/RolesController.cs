using Equipments.Api;
using Equipments.Identity.Data;
using Equipments.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Equipments.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;

        public RolesController(ApplicationDbContext dbContext, UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoleRequest([FromBody] CreateRoleRequestModel model)
        {
            var isCopyRequest = await _dbContext.RoleRequests.AnyAsync(r => r.UserId == model.UserID && r.Status == RoleRequestStatuses.Обрабатывается);
            if (isCopyRequest)
            {
                return BadRequest(new ErrorResponse("Уже создан запрос на выдачу роли и он находится в обработке, повторите попытку позже"));
            }

            var user = await _userManager.FindByIdAsync(model.UserID);
            if (user == null)
            {
                return BadRequest(new ErrorResponse("Такого пользователя не существует"));
            }


            var role = await _dbContext.Roles.FirstOrDefaultAsync(role => role.Name == model.Role);

            RoleRequest request = new RoleRequest()
            {
                UserId = model.UserID,
                RoleId = role.Id,
                Status = RoleRequestStatuses.Обрабатывается
            };

            _dbContext.RoleRequests.Add(request);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
