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
using Microsoft.Extensions.Logging;

namespace AspNetCorePublisherWebAPI
{
    public class Startup
    {
        // 
        public IConfiguration Configuration { get; set; }

        // Needs constructor to access configuration file
        public Startup()
        {
            // set base path for searching configuration file
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Console.WriteLine(Directory.GetCurrentDirectory());
            Configuration = builder.Build();

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // The pipeline defines how the app response to requests 
        // Common task for the pipeline includes:
        // serve up static files (HTML / JSON) 
        // add error page
        // Configure set up inversion of control container 
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var message = Configuration["Message"];
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(message + " in " + Directory.GetCurrentDirectory());
            });
        }
    }
}
