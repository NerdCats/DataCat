namespace DataCat.Core.Exception
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;

    public class ApiError
    {
        public string Message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string StackTrace { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Errors { get; private set; }

        public ApiError(string message, IEnumerable<ModelError> modelErrors=null)
        {
            this.Message = message;
            if (modelErrors!=null)
            {
                this.Errors = modelErrors.Select(x => x.ErrorMessage);
            }
        }

        public ApiError(IEnumerable<string> Errors)
        {
            this.Message = "Api errors detected";
            this.Errors = Errors;
        }
    }
}
