using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using pertemuan1.Data;
using pertemuan1.Models;
using pertemuan1.Repository.BlogRevository;
using pertemuan1.Service;
using pertemuan1.Service.BlogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pertemuan1
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
            services.AddDbContext<AppDbContext>(o =>
            {
                o.UseMySQL(Configuration.GetConnectionString("mysql")); //sesuaikan namanya
            });

            services.AddAuthentication("CookieAuth")
               .AddCookie("CookieAuth", options =>
               {
                   options.LoginPath = "/Akun/Masuk";
                   options.AccessDeniedPath = "/Home/Dilarang";
               }
            );
            // Mendaftarkan Repo
            services.AddScoped<IBlogRevository, BlogRevository>();

            // Mendaftarkan Service
            services.AddScoped<IBlogService, BlogService>();

            // daftar fileService
            services.AddTransient<FileService>();

            // Mendaftarkan EmailServe
            services.AddTransient<EmailService>();

            // Ambil data dari appsetting.json
            services.Configure<Email>(Configuration.GetSection("AturEmail"));


            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "default",
                    areaName:"Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                   name: "default",
                   areaName: "User",
                   pattern: "User/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
