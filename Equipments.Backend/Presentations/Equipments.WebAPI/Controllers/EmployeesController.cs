using Equipments.Application.Employees.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Equipments.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var query = new GetEmployees.Query();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        //[Authorize]
        [HttpGet("me")]
        public async Task<ActionResult> GetMeInfo()
        {
            var query = new GetEmployeeByID.Query
            {
                IDUser = UserGuid
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [Authorize]
        [HttpGet("me/image")]
        public async Task<ActionResult> GetMeImage()
        {
            var query = new GetImage.Query
            {
                ID = UserGuid
            };
            var image = await Mediator.Send(query);

            var imageBytes = FindAndGetImage(image, out string path);

            var provider = new FileExtensionContentTypeProvider();
            provider.TryGetContentType(path, out string contentType);
            return File(imageBytes, contentType);

        }

        [HttpGet("{id}/image")]
        public async Task<ActionResult> GetImage(Guid id)
        {
            var query = new GetImage.Query();
            query.ID = id;
            string image = await Mediator.Send(query);


            var imageBytes = FindAndGetImage(image, out string path);

            var provider = new FileExtensionContentTypeProvider();
            provider.TryGetContentType(path, out string contentType);
            return File(imageBytes, contentType);
        }

        private byte[]? FindAndGetImage(string file, out string path)
        {
            path = AppDomain.CurrentDomain.BaseDirectory + @"\Images\Employees\" + file;
            return System.IO.File.ReadAllBytes(path);
        }
    }
}
