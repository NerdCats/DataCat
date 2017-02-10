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

            var result = await dbcollection.Find(queryDocument).FirstOrDefaultAsync();
            var jsonResult = result.ToJson(new MongoDB.Bson.IO.JsonWriterSettings() {
                OutputMode = MongoDB.Bson.IO.JsonOutputMode.Strict,
                Indent = true,
                GuidRepresentation = GuidRepresentation.CSharpLegacy
            });
            return new ContentResult()
            {
                Content = jsonResult,
                StatusCode= 200,
                ContentType = "application/json"
            };
        }
    }
}
