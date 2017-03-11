using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace DataCat.Microservice.Core
{
    public class MicroServiceHost
    {
        public MicroServiceHost()
        {

        }

        public static IWebHost CreateHost<TStartup>(string applicationName) where TStartup : class
        {
            var host = new WebHostBuilder()
                .UseSetting("applicationName", applicationName)
                .CaptureStartupErrors(true)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<TStartup>()
                .Build();

            return host;
        }
    }
}
