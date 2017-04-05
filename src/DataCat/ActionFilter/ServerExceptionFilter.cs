namespace DataCat.ActionFilter
{
    using DataCat.Core.Exception;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Newtonsoft.Json;
    using System;
    using System.Net;

    /// <summary>
    /// Generic exception filter for unhandled exceptions and generating Http responses for it. 
    /// Should never return a 500 Internal Server Error in production
    /// </summary>
    public class ServerExceptionFilter : ExceptionFilterAttribute
    {
        private IHostingEnvironment _hostingEnvironment;

        public ServerExceptionFilter(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public override void OnException(ExceptionContext context)
        {
            ApiError error = null;
            var result = new ContentResult();
            result.StatusCode = (int)HttpStatusCode.InternalServerError;

            if (context.Exception is ApiException)
            {
                var ex = context.Exception as ApiException;
                error = new ApiError(ex.Message, ex.ModelErrors);
                result.StatusCode = (int) ex.StatusCode;
            }
            else if(context.Exception is UnauthorizedAccessException)
            {
                error = new ApiError("Unauthorized Access");
                result.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else if (context.Exception is NotImplementedException)
            {
                error = new ApiError("Workflow not implemented");
                result.StatusCode = (int)HttpStatusCode.NotImplemented;
            }
            else if (context.Exception is EntityNotFoundException)
            {
                error = new ApiError(context.Exception.Message);
                result.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else
            {
#if !DEBUG
                var msg = "An unhandled error occurred.";                
                string stack = null;
#else
                var msg = context.Exception.GetBaseException().Message;
                string stack = context.Exception.StackTrace.Trim();        
#endif
                error = new ApiError(msg);
                error.StackTrace = stack;
                result.Content = JsonConvert.SerializeObject(error);
                result.ContentType = "application/json";

                context.Result = result;
            }
        }
    }
}
