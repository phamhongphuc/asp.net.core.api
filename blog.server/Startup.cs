using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;
using NJsonSchema;
using NSwag.AspNetCore;
using blog.server.Authentication;
using blog.server.DataAccesses.Base;
using blog.server.DataTransfers;
using blog.server.Middleware;
using blog.server.Models.Enums;

namespace blog.server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            AuthorizationHelper.Initialize(configuration);
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            Mapper.Initialize(config => config.AddProfile<MappingProfile>());

            services.AddTransient<ExceptionCatcherMiddleware>();

            services.AddRouting(options => { options.LowercaseUrls = true; });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => options
                    .SerializerSettings
                    .Converters
                    .Add(new StringEnumConverter())
                );

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = Configuration["Swagger:Version"];
                    document.Info.Title = Configuration["Swagger:Title"];
                    document.Info.Description = Configuration["Swagger:Description"];
                };
            });

            services
               .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = Configuration["JWT:issuer"],
                        ValidAudience = Configuration["JWT:audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:key"]))
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    nameof(EnumAccess.BannedUser),
                    policy => policy.Requirements.Add(new AccountAccess(EnumAccess.BannedUser | EnumAccess.NormalUser | EnumAccess.Moderator | EnumAccess.Administrator))
                );
                options.AddPolicy(
                    nameof(EnumAccess.NormalUser),
                    policy => policy.Requirements.Add(new AccountAccess(EnumAccess.NormalUser | EnumAccess.Moderator | EnumAccess.Administrator))
                );
                options.AddPolicy(
                    nameof(EnumAccess.Moderator),
                    policy => policy.Requirements.Add(new AccountAccess(EnumAccess.Moderator | EnumAccess.Administrator))
                );
                options.AddPolicy(
                    nameof(EnumAccess.Administrator),
                    policy => policy.Requirements.Add(new AccountAccess(EnumAccess.Administrator))
                );
            });

            services.AddSingleton<IAuthorizationHandler, AccountAccessHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                RealmDatabase.Config.ShouldDeleteIfMigrationNeeded = true;
            }

            app.UseMiddleware<ExceptionCatcherMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUi3(config => { config.WithCredentials = true; });
            app.UseReDoc(config => config.Path = "/redoc");

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
