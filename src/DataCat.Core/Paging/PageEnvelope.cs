namespace DataCat.Core.Paging
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PageEnvelope<T>
    {
        [JsonIgnore]
        public IPagingHelper paginationHelper;

        public PaginationHeader pagination;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<T> data { get; set; }

        public PageEnvelope(
                    long total,
                    long page,
                    int pageSize,
                    string routeName,
                    IEnumerable<T> data,
                    HttpRequest request,
                    IUrlHelper urlHelper)
        {
            var paginationHelper = new PagingHelper(urlHelper);
            var totalPages = (int)Math.Ceiling((double)total / pageSize);

            var nextPage = page < totalPages - 1 ? paginationHelper.GeneratePageUrl(routeName, page + 1, pageSize, request) : string.Empty;
            var prevPage = page > 0 ? paginationHelper.GeneratePageUrl(routeName, page - 1, pageSize, request) : string.Empty;

            this.pagination = new PaginationHeader(total, page, pageSize, data != null ? data.Count() : 0, nextPage, prevPage);
            this.data = data;
        }
    }
}
