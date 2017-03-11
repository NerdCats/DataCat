using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DataCat.Microservice.Core
{
    public class MicroServiceHost
    {
        public MicroServiceHost()
        {

        }

        public static IWebHost CreateHost<TStartup>(
            string applicationName, 
            string defaultHostingUrl,
            string[] commandLineArgs) where TStartup : class
        {
            var hostingConfiguration = new ConfigurationBuilder()
                .AddJsonFile("hosting.json", optional: true)
                .AddCommandLine(commandLineArgs)
                .Build();

            var host = new WebHostBuilder()
                .UseSetting("applicationName", applicationName)
                .UseUrls(defaultHostingUrl) 
                .UseConfiguration(hostingConfiguration)
                .CaptureStartupErrors(true)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<TStartup>()
                .Build();

            return host;
        }
    }
}
