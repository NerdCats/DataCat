namespace DataCat.Microservice.Core.Options
{
    using System.Collections.Generic;

    public class SecurityOptions
    {
        public string Authority { get; set; }
        public List<string> AllowedScopes { get; set; }
        public bool RequireHttpsMetadata { get; set; }
    }
}