namespace DataCat.Core.Services
{
    using DataCat.Core.Db;
    using DataCat.Core.Entity;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using System;

    public class DataConnectionService : IDataConnectionService
    {
        public IMongoCollection<DataConnection> Collection { get; private set; }
        public DataConnectionService(IDbContext dbContext)
        {
            this.Collection = dbContext.DataConnectionCollection;
        }

        public async Task<DataConnection> Create(DataConnection connection)
        {
            await this.Collection.InsertOneAsync(connection);
            return connection;
        }

        public async Task<DataConnection> Find(string id)
        {
            // TODO: Throw an exception or may be catch it so we know when something is not here. :)
            var result = await this.Collection.Find(x => x.Id == id).FirstAsync();
            return result;
        }

        public async Task<DataConnection> Delete(string id)
        {
            var result = await this.Collection.FindOneAndDeleteAsync(x => x.Id == id);
            return result;
        }

        public async Task<DataConnection> Update(DataConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

            if (string.IsNullOrWhiteSpace(connection.Id))
                throw new ArgumentNullException(nameof(connection.Id));

            var result = await this.Collection.FindOneAndReplaceAsync(x => x.Id == connection.Id, connection);
            return result;
        }
    }
}
