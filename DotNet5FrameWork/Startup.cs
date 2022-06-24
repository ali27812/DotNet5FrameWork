using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

using WebFramework.Middlewares;
using ElmahCore.Mvc;
using ElmahCore.Sql;
using WebFramework.Configuration;
using Common;
using System;
using AutoMapper;
using Entites;
using WebFramework.CustomMapping;
using Microsoft.Extensions.Logging;
using Data.Contracts;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using WebFramework.Swagger;

namespace DotNet5FrameWork
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }
        private SiteSettings _siteSetting;
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AutoMapperConfiguration.InitializeAutoMapper();
            _siteSetting = Configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {          
            services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));
            services.AddDbContext(Configuration);
            services.AddJwtAuthentication(_siteSetting.JwtSettings);
            //this two equales addmvc
            services.AddControllers(options =>
            {
                options.Filters.Add(new AuthorizeFilter());                
            });
            //services.AddCustomApiVersioning();
            services.AddSwaggerGen(option => { option.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); });
            //services.AddSwagger();
            //services.AddRazorPages();
            //this two equales addmvc
            return services.BuildAutofacServiceProvider();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCustomExceptionHandler();

            if (env.IsDevelopment())
            {
               // app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<AuthenticationMiddleware>();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(option => { option.SwaggerEndpoint("/swagger/v1/swagger.json", "doc-v1");});
            //app.UseSwaggerAndUI();

            //app.UseAuthorization();
            app.UseAuthentication();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(name: "default", pattern: "{Values}/{Index}");
                //endpoints.MapRazorPages();
            });
        }
    }
}
