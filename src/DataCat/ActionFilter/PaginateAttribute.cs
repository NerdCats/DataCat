namespace DataCat.ActionFilter
{
    using DataCat.Core.Paging;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class PaginateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var queryParams = context.HttpContext.Request.Query;
            if (!queryParams.ContainsKey(PagingQueryParameters.Page))
            {
                context.HttpContext.Request.QueryString =
                    context.HttpContext.Request.QueryString.Add(PagingQueryParameters.Page, "0");
            }

            if (!queryParams.ContainsKey(PagingQueryParameters.PageSize))
            {
                context.HttpContext.Request.QueryString =
                    context.HttpContext.Request.QueryString.Add(PagingQueryParameters.PageSize, PagingConstants.MaxPageSize.ToString());
            }

            if (!queryParams.ContainsKey(PagingQueryParameters.Envelope))
            {
                context.HttpContext.Request.QueryString =
                    context.HttpContext.Request.QueryString.Add(PagingQueryParameters.Envelope, true.ToString());
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!(context.Result is ObjectResult))
            {
                throw new InvalidOperationException("Paginated results needs to be an ObjectResult");
            }

            var result = context.Result as ObjectResult;
            var value = result.Value as IQueryable<object>;

            var page = Int32.Parse(context.HttpContext.Request.Query[PagingQueryParameters.Page].First());
            var pageSize = Int32.Parse(context.HttpContext.Request.Query[PagingQueryParameters.PageSize].First());

            var total = value.Count();
            var content = value.Skip(page * pageSize).Take(pageSize).ToList();
            var controller = context.Controller as Controller;

            var pagedResult = new PageEnvelope<object>(
                total, page, pageSize, context.ActionDescriptor.AttributeRouteInfo.Name,
                content, context.HttpContext.Request , controller.Url);

            context.Result = new OkObjectResult(pagedResult);
        }
    }
}
