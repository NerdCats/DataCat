namespace DataCat.Auth
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Builder;
    using DataCat.Microservice.Core;

    public class Program
    {
        public static void Main(string[] args)
        {
            /**
             *  DataCat's own authentication module. 
             *  It can be configured from the client whether
             *  DataCat will use this or another authentication
             *  module to be used with it.
             **/

            var host = MicroServiceHost.CreateHost<Startup>("DataCat.Auth");
            host.Run();
        }
    }
}
