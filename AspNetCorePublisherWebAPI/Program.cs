using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace AspNetCorePublisherWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel() // cross-platform web server 
                .UseContentRoot(Directory.GetCurrentDirectory()) // root of web app
                .UseIISIntegration() // ISS Express as a reverse proxy server 
                .UseStartup<Startup>() // startup type by web host - default: Startup 
                .UseApplicationInsights()
                .Build(); // builds WebHostBuilder to host

            host.Run(); // starts app and blocks the calling thread until shut down  
        }
    }
}
