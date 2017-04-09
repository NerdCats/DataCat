namespace DataCat.Core.Paging
{
    using Microsoft.AspNetCore.Http;

    public interface IPagingHelper
    {
        string GeneratePageUrl(string routeName, long page, long pageSize, HttpRequest request);
    }
}
