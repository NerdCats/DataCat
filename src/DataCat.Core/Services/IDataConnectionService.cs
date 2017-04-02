namespace DataCat.Core.Services
{
    using System.Threading.Tasks;
    using DataCat.Core.Entity;
    using MongoDB.Driver;

    public interface IDataConnectionService
    {
        IMongoCollection<DataConnection> Collection { get; }

        Task<DataConnection> Create(DataConnection connection);
        Task<DataConnection> Delete(string id);
        Task<DataConnection> Find(string id);
        Task<DataConnection> Update(DataConnection connection);
    }
}