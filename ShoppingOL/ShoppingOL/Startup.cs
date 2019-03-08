using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ShoppingOL.Data;

namespace ShoppingOL
{
    public class Startup
    {

        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CustomDBContext>(cfg => {
                cfg.UseSqlServer(_config.GetConnectionString("ShoppingOLConnectionString"));
            });

            //AutoMapper
            services.AddAutoMapper();

            services.AddTransient<ShoppingolSeeder>();

            //Register the repository
            services.AddScoped<IShoppingRepository, ShoppingRepository>();

            services.AddMvc()
              .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
              .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
           
            app.UseStaticFiles();
            app.UseNodeModules(env);

            app.UseMvc(cfg => {
                cfg.MapRoute("Default","{controller}/{action}/{id?}", 
                    new { controller ="App" ,Action = "Index"});
            });
        }
    }
}
