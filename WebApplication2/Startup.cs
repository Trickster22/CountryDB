using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CountryProject.Storage;
using Microsoft.EntityFrameworkCore;
using CountryProject.Managers.Faiths;
using CountryProject.Managers.Countries;
using CountryProject.Managers.Polities;

namespace CountryProject
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;

        public Startup(IHostingEnvironment hostingEnviroment)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostingEnviroment.ContentRootPath).AddJsonFile("CountryDBSettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CountryDataContext>(options => options.UseSqlServer(_configurationRoot.GetConnectionString("CountryDB")));
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddTransient<IFaithManager, FaithManager>();
            services.AddTransient<ICountryManager, CountryManager>();
            services.AddTransient<IPolityManager, PolityManager>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=HomePage}/{id?}");
            });
        }
    }
}
