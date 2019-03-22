using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCore.Demo.Middlewares;
using MyCore.Demo.Models;
using MyCore.Demo.Repositories;
using MyCore.Demo.Services;

namespace MyCore.Demo
{
    public class Startup
    {
        public Startup()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("AppSettings.json");
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(typeof(EmployeeRepository));
            services.AddTransient(typeof(EmployeeService));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*
            //启用默认页面
            app.UseDefaultFiles();
            //启用静态页面
            app.UseStaticFiles();
            //*/

            //*这个UseFileServer方法就等于UseDefaultFiles方法+UseStaticFiles方法
            app.UseFileServer();
            //*/

            app.UseMiddleware<AuthMiddleware>();

            //*
            //启用默认的路由规则
            //app.UseMvcWithDefaultRoute();

            //启用自定义的路由规则
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            });
            //*/

            //app.UseWelcomePage();


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
                //await context.Response.WriteAsync("TestNumer:" + Configuration["TestNumber"] + ",TestString:" + Configuration["TestString"]);
            });
        }
    }
}
