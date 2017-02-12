using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace DataCat.Core
{
    public interface IDataService
    {
        Task<List<BsonDocument>> Execute(string collectionName, QueryDocument document);
        Task<List<BsonDocument>> Execute(string collectionName, AggregateDocument document);
    }
}