namespace DataCat.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Core;
    using MongoDB.Driver;
    using MongoDB.Bson;
    using System.Threading.Tasks;

    [Route("api")]
    public class DataController : Controller
    {
        private IDbContext dbContext;

        public DataController(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("{collectionName}")]
        public async Task<IActionResult> Post(string collectionName, [FromBody] QueryDocument querydocument)
        {
            if (string.IsNullOrWhiteSpace(collectionName))
                return BadRequest();

            var dbcollection = this.dbContext.GetCollection(collectionName);
            var queryDocument = BsonDocument.Parse(querydocument.query.ToString());

            var fluentQuery = dbcollection
                .Find(queryDocument);


            if (querydocument.project != null)
            {
                var projectDocument = BsonDocument.Parse(querydocument.project.ToString());
                fluentQuery = fluentQuery
                    .Project(projectDocument);
            }

            if (querydocument.sort != null)
            {
                var sortDocument = BsonDocument.Parse(querydocument.sort.ToString());
                fluentQuery = fluentQuery
                    .Sort(sortDocument);
            }

            var result = await fluentQuery
                .Skip(querydocument.skip)
                .Limit(querydocument.limit)
                .ToListAsync();

            return Ok(result);
        }
    }
}
