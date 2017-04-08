namespace DataCat.Core.Exception
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System;
    using System.Linq;
    using System.Net;
    using System.Collections.Generic;

    public class ApiException: Exception
    {
        public HttpStatusCode StatusCode;
        public IEnumerable<ModelError> ModelErrors { get; private set; }

        public ApiException(string message, 
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
            ModelStateDictionary stateDict = null) : base(message)
        {
            this.StatusCode = statusCode;
            if (stateDict != null)
                this.ModelErrors = stateDict.Where(x => x.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors);
        }

        public ApiException(Exception ex, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(ex.Message)
        {
            StatusCode = statusCode;
        }
    }
}
