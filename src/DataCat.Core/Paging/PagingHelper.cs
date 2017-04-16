namespace DataCat.Core.Paging
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PagingHelper : IPagingHelper
    {
        private IUrlHelper urlHelper;

        public PagingHelper(IUrlHelper urlhelper)
        {
            this.urlHelper = urlhelper;
        }

        public virtual string GeneratePageUrl(
            string routeName, 
            long page, 
            long pageSize, 
            HttpRequest request)
        {
            var queryParams = request.Query.ToDictionary(x => x.Key, x => x.Value.ToString());
            queryParams[PagingQueryParameters.Page] = new List<string>() { page.ToString() };
            queryParams[PagingQueryParameters.PageSize] = new List<string>() { pageSize.ToString() };

            return urlHelper.Link(routeName, queryParams);
        }

        public static int ValidatePageSize(int maxPageSize, int pageSize, int page)
        {
            if (pageSize == 0)
                throw new ArgumentException("Page size cant be 0");

            if (page < 0)
                throw new ArgumentException("Page index less than 0 provided");

            pageSize = pageSize > maxPageSize ? maxPageSize : pageSize;
            return pageSize;
        }
    }
}
