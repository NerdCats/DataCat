namespace DataCat.Core.Services
{
    using System.Threading.Tasks;
    using DataCat.Core.Entity;
    using MongoDB.Driver;

    public interface IFilterService
    {
        IMongoCollection<Filter> Collection { get; }

        Task<Filter> Create(Filter filter);
        Task<Filter> Delete(string id);
        Task<Filter> Find(string id);
        Task<Filter> Update(Filter filter);
    }
}