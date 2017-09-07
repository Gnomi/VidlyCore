using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VidlyCore.Data;
using VidlyCore.Models;
using VidlyCore.Services;

namespace VidlyCore
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();

            //this is DI method
            ////https://dotnetthoughts.net/using-automapper-in-aspnet-core-project/
            ////https://stackoverflow.com/questions/42916182/trying-to-add-automapper-to-netcore1-1-not-recognising-services-addautomapper
            //var config = new AutoMapper.MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new MappingProfile());
            //});
            //var mapper = config.CreateMapper();
            //services.AddSingleton(mapper);



            //static method
            //https://stackoverflow.com/questions/41284349/automapper-error-saying-mapper-not-initialized
            AutoMapper.Mapper.Initialize(c=>c.AddProfile<MappingProfile>());
//            services.AddAutoMapper();//This is the line you add.
            
            // services.AddAutoMapper(typeof(Startup));  // <-- newer automapper version uses this signature.

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

//                routes.MapSpaFallbackRoute("DefaultAPI", "api/{controller}/{id?}");
            });
        }
    }
}
