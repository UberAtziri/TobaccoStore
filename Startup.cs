using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using React.AspNet;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using JavaScriptEngineSwitcher.ChakraCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TobaccoStore.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Builder;
using TobaccoStore.Data;
using TobaccoStore.MappingProfile;
using AutoMapper;
using TobaccoStore.Entities;
using TobaccoStore.Data.EFCore;

namespace TobaccoStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = AuthOptions.ISSUER,

                            ValidateAudience = true,
                            ValidAudience = AuthOptions.AUDIENCE,
                            ValidateLifetime = true,

                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            ValidateIssuerSigningKey = true,
                        };
                    });
            
            services.AddDbContext<TobaccoContext>(options =>
            {
                options.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = Tobacco; Trusted_Connection = True");
            });
            services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<EFCoreTobaccoRepository>();
            services.AddScoped<EFCoreUsersRepository>();
            services.AddScoped<EFCoreRoleRepository>();
            services.AddScoped<EFCoreOrderRepository>();
            services.AddReact();
            services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName).AddChakraCore();
            services.AddControllers(mvcOptions =>
                mvcOptions.EnableEndpointRouting = false);
            //services.AddAutoMapper(typeof(TobaccoMappings));

            services.AddOData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();


            app.UseReact(config => { });

            app.UseDefaultFiles();

            app.UseStaticFiles();
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Select().Expand().Filter().OrderBy().Count();
                routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
               // routeBuilder.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                
            });
        }
        IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<TobaccoEntity>("Tobacco");
            odataBuilder.EntitySet<UserEntity>("Users");
            odataBuilder.EntitySet<OrderEntity>("Orders");
            odataBuilder.EntitySet<RoleEntity>("Roles");

            return odataBuilder.GetEdmModel();
        }
    }
}
