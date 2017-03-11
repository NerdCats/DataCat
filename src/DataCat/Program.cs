namespace DataCat
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Builder;
    using DataCat.Microservice.Core;

    public class Program
    {
        public static void Main(string[] args)
        {
            /**
             *  TODO: Running on default hosting address here, need to make sure 
             *  where we would want to host DataCat. Having a setting would be 
             *  definitely nice here.
             * */
             
            var host = MicroServiceHost.CreateHost<Startup>("DataCat", "http://*:5000", args);
            host.Run();
        }
    }
}
