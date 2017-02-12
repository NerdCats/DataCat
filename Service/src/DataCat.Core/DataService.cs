namespace DataCat.Core
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class DataService
    {
        private IDbContext dbContext;

        public DataService(IDbContext context)
        {
            this.dbContext = context;
        }

        public async Task<List<BsonDocument>> Execute(string collectionName, QueryDocument document)
        {
            var dbcollection = this.dbContext.GetCollection(collectionName);
            var queryDocument = BsonDocument.Parse(document.query.ToString());

            var fluentQuery = dbcollection
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

        public async Task<List<BsonDocument>> Execute(string collectionName, AggregateDocument document)
        {
            return null;
        }
    }
}
