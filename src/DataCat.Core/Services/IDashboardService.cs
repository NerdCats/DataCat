namespace DataCat.Core.Services
{
    using System.Threading.Tasks;
    using DataCat.Core.Entity;
    using MongoDB.Driver;


    public interface IDashboardService
    {
        IMongoCollection<Dashboard> Collection { get; }

        Task<Dashboard> Create(Dashboard dashboard);
        Task<Dashboard> Delete(string id);
        Task<Dashboard> Find(string id);
        Task<Dashboard> Update(Dashboard connection);
    }
}