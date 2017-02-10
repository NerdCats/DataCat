using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace DataCat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /**
             *  TODO: Running on default hosting address here, need to make sure 
             *  where we would want to host DataCat. Having a setting would be 
             *  definitely nice here.
             * */

            var host = new WebHostBuilder()
                .UseSetting("applicationName", "DataCat")
                .CaptureStartupErrors(true)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
