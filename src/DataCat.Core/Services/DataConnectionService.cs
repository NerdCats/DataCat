﻿namespace DataCat.Core.Services
{
    using DataCat.Core.Db;
    using DataCat.Core.Entity;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using System;
    using DataCat.Core.Exception;

    public class DataConnectionService : IDataConnectionService
    {
        public IMongoCollection<DataConnection> Collection { get; private set; }
        public DataConnectionService(IDbContext dbContext)
        {
            this.Collection = dbContext.DataConnectionCollection;
        }

        public async Task<DataConnection> Create(DataConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

            await this.Collection.InsertOneAsync(connection);
            return connection;
        }

        public async Task<DataConnection> Find(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException(nameof(id));

            var result = await this.Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (result == null)
                throw new EntityNotFoundException(typeof(DataConnection), id);

            return result;
        }

        public async Task<DataConnection> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException(nameof(id));

            var result = await this.Collection.FindOneAndDeleteAsync(x => x.Id == id);
            if (result == null)
                throw new EntityDeleteException(typeof(DataConnection), id);

            return result;
        }

        public async Task<DataConnection> Update(DataConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

            if (string.IsNullOrWhiteSpace(connection.Id))
                throw new ArgumentNullException(nameof(connection.Id));

            var result = await this.Collection.FindOneAndReplaceAsync(x => x.Id == connection.Id, connection);
            if (result == null)
                throw new EntityUpdateException(typeof(DataConnection), connection.Id);

            return result;
        }
    }
}
