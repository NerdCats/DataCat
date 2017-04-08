namespace DataCat.Core
{
    using DataCat.Core.Entity;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DataService : IDataService
    {
        private MongoClient mongoClient;
        private IMongoDatabase database;

        public DataService(DataConnection connection)
        {
            this.mongoClient = new MongoClient(connection.ConnectionString);
            this.database = mongoClient.GetDatabase(connection.Database);
        }

        public async Task<List<BsonDocument>> ExecuteAsync(string collectionName, QueryDocument document)
        {
            var collection = this.database.GetCollection<BsonDocument>(collectionName);
            var queryDocument = BsonDocument.Parse(document.Query.ToString());

            var fluentQuery = collection
                .Find(queryDocument);

            if (document.Project != null)
            {
                var projectDocument = BsonDocument.Parse(document.Project.ToString());
                fluentQuery = fluentQuery
                    .Project(projectDocument);
            }

            if (document.Sort != null)
            {
                var sortDocument = BsonDocument.Parse(document.Sort.ToString());
                fluentQuery = fluentQuery
                    .Sort(sortDocument);
            }

            var result = await fluentQuery
                .Skip(document.Skip)
                .Limit(document.Limit)
                .ToListAsync();

            return result;
        }

        public async Task<List<BsonDocument>> ExecuteAsync(string collectionName, AggregateDocument document)
        {
            var collection = this.database.GetCollection<BsonDocument>(collectionName);

            // TODO: May be we need a smart way to expose aggregation options? May be?

            var aggPipeline = document.aggregate
                .Select(x => BsonDocument.Parse(x.ToString()))
                .ToArray();

            var aggregateFluent = collection.Aggregate();
            foreach (var stage in aggPipeline)
            {
                aggregateFluent = aggregateFluent.AppendStage<BsonDocument>(stage);
            }

            var result = await aggregateFluent
                .Skip(document.skip)
                .Limit(document.limit)
                .ToListAsync();

            return result;
        }
    }
}
