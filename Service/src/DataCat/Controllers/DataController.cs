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
        private IDataService dataService;

        public DataController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        [HttpPost("{collectionName}/q")]
        public async Task<IActionResult> PostQuery(string collectionName, [FromBody] QueryDocument queryDocument)
        {
            if (string.IsNullOrWhiteSpace(collectionName))
                return BadRequest();

            var result = await dataService.Execute(collectionName, queryDocument);

            return Ok(result);
        }

        [HttpPost("{collectionName}/a")]
        [HttpPost]
        public IActionResult PostAggregation(string collectionName, [FromBody] QueryDocument querydocument)
        {
            return Ok();
        }
    }
}
