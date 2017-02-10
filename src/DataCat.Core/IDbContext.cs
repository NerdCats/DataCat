using MongoDB.Bson;
using MongoDB.Driver;

namespace DataCat.Core
{
    public interface IDbContext
    {
        IMongoDatabase Database { get; }

        IMongoCollection<BsonDocument> GetCollection(string collectionName);
    }
}