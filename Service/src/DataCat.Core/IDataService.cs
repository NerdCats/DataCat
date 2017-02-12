namespace DataCat.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MongoDB.Bson;

    public interface IDataService
    {
        Task<List<BsonDocument>> ExecuteAsync(string collectionName, QueryDocument document);
        Task<List<BsonDocument>> ExecuteAsync(string collectionName, AggregateDocument document);
    }
}  