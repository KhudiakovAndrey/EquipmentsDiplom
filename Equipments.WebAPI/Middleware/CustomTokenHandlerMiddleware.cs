using Equipments.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.WebAPI.Middleware
{
    public class CustomTokenHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IEquipmentsDbContext _dbContext;

        public CustomTokenHandlerMiddleware(RequestDelegate next, IEquipmentsDbContext dbContext)
        {
            _next = next;
            _dbContext = dbContext;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");
            if (token != null)
            {
                try
                {
                    var findToken = await _dbContext.Tokens.FirstOrDefaultAsync(tokenDb =>
                        tokenDb.Tokencontent == token);
                    if (findToken == null)
                    {
                        context.User = null;
                        context.Response.StatusCode = 401;
                        return;
                    }
                }
                catch (Exception)
                {
                    context.User = null;
                    context.Response.StatusCode = 401;
                    return;
                }
            }
            await _next(context);
        }
    }
}
