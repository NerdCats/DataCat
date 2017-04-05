namespace DataCat.Core.Exception
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ApiError
    {
        public string Message { get; set; }
        public string Detail { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Errors { get; private set; }

        public ApiError(string message)
        {
            this.Message = message;
        }

        public ApiError(IEnumerable<string> Errors)
        {
            this.Message = "Api errors detected";
            this.Errors = Errors;
        }
    }
}
