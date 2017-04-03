namespace DataCat.ActionFilter
{
    using DataCat.Core.Exception;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Net;

    /// <summary>
    /// Generic exception filter for unhandled exceptions and generating Http responses for it. 
    /// Should never return a 500 Internal Server Error in production
    /// </summary>
    public class ServerExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception != null && context.HttpContext.Request != null)
            {
                var result = new ContentResult();
                if (context.Exception is NotImplementedException)
                    result.StatusCode = (int)HttpStatusCode.NotImplemented;
                else if (context.Exception is EntityNotFoundException)
                    result.StatusCode = (int)HttpStatusCode.NotFound;
                else if (context.Exception is InvalidOperationException)
                    result.StatusCode = (int)HttpStatusCode.Forbidden;
                else if (context.Exception is ArgumentException)
                    result.StatusCode = (int)HttpStatusCode.BadRequest;
                else if (context.Exception is FormatException)
                    result.StatusCode = (int)HttpStatusCode.BadRequest;
                else if (context.Exception is ValidationException)
                    result.StatusCode = (int)HttpStatusCode.BadRequest;
                else if (context.Exception is NotSupportedException)
                    result.StatusCode = (int)HttpStatusCode.BadRequest;
                else if (context.Exception is UnauthorizedAccessException)
                    result.StatusCode = (int)HttpStatusCode.Unauthorized;
                else
                    throw context.Exception;

                // TODO: May be a default exception/error payload here?
                result.Content = context.Exception.Message;
                result.ContentType = "application/json";
                context.Result = result;
            }
        }
    }
}
