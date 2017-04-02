namespace DataCat.Core
{
    using DataCat.Core.Db;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DataService : IDataService
    {
        private IDbContext dbContext;

        public DataService(IDbContext context)
        {
            this.dbContext = context;
        }

        public async Task<List<BsonDocument>> ExecuteAsync(string collectionName, QueryDocument document)
        {
            var collection = this.dbContext.GetCollection(collectionName);
            var queryDocument = BsonDocument.Parse(document.query.ToString());

            var fluentQuery = collection
                .Find(queryDocument);

            if (document.project != null)
            {
                var projectDocument = BsonDocument.Parse(document.project.ToString());
                fluentQuery = fluentQuery
                    .Project(projectDocument);
            }

            if (document.sort != null)
            {
                var sortDocument = BsonDocument.Parse(document.sort.ToString());
                fluentQuery = fluentQuery
                    .Sort(sortDocument);
            }

            var result = await fluentQuery
                .Skip(document.skip)
                .Limit(document.limit)
                .ToListAsync();

            return result;
        }

        public async Task<List<BsonDocument>> ExecuteAsync(string collectionName, AggregateDocument document)
        {
            var collection = this.dbContext.GetCollection(collectionName);

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
