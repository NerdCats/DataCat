﻿namespace DataCat.Core
{
    using DataCat.Core.Entity;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public interface IDbContext
    {
        IMongoDatabase Database { get; }
        IMongoCollection<DataConnection> DataConnectionCollection { get; }

        IMongoCollection<BsonDocument> GetCollection(string collectionName);
    }
}