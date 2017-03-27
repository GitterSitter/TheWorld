using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheWorld.Services;
using Microsoft.Extensions.Configuration;
using TheWorld.Models;

namespace TheWorld
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json").AddEnvironmentVariables();

            _config = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton(_config);


            if (_env.IsDevelopment() || _env.IsEnvironment("Testing"))
            {
                //Creates an instance of this service when needed
                services.AddScoped<IMailService, DebugMailService>();
            }
            else
            {
                //implement real mail service
            }

            services.AddDbContext<WorldContext>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // app.UseDefaultFiles();

            //This is executed only in an developing environment
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            


            app.UseStaticFiles();

            app.UseMvc(config =>

            {
                config.MapRoute(
                name: "Default",
                template: "{controller}/{action}/{id?}",
                defaults: new { controller = "App", action = "Index" });

            });

        }
    }
}



//public void Configure(IApplicationBuilder app)
//{
//    app.UseDefaultFiles();
//    //    app.UseStaticFiles();
//    app.UseMvc(config =>

//    {
//        config.MapRoute(
//        name: "Default",
//        template: "{controller}/{action}/{id?}",
//        defaults: new { controller = "App", action = "Index" });

//    });

//}

//    }
//}
