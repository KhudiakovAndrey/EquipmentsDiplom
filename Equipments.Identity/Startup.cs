using Equipments.Identity.Data;
using Equipments.Identity.Models;
using Equipments.Identity.Services.EmailSender;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

//using Microsoft.AspNetCore.Authentication.Jwt
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Identity
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("DbUsersConnection")));
            //services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddIdentityServer()
                .AddAspNetIdentity<AppUser>()
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.Clients)
                //Добавляем кастомное добавление претензий в токен
                .AddProfileService<ProfileClaimsService>()
                .AddDeveloperSigningCredential();

            services.AddAuthentication(config =>
            {
                //Сообщаяем Authentication чтобы схема во всех атрибутов по умолчанию была Bearer.
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer("Bearer", options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    ////options.Authority = "https://localhost:5001";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        //ValidateLifetime = true,
                        ValidateIssuer = true,
                        ValidIssuer = "Equipments.Identity.Server",
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1ea1ab0f-315c-4d8b-a1ab-37ede07f1fbe"))
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["jwt"];
                            return Task.CompletedTask;
                        }
                    };
                });

            services.Configure<EmailSettings>(Configuration.GetSection("Email"));
            services.AddTransient<IEmailSender>(options =>
            {
                return new MailKitEmailSender(options.GetService<IOptions<EmailSettings>>()?.Value!);
            });


            //services.AddAuthentication();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }

            app.UseIdentityServer();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
