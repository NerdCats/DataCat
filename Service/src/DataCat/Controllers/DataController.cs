namespace DataCat.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Core;
    using System.Threading.Tasks;
    using System.Reflection;

    [Route("api")]
    public class DataController : Controller
    {
        private IDataService dataService;

        public DataController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("DataCat " + typeof(Startup)
                .GetTypeInfo()
                .Assembly
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                .InformationalVersion);
        }

        [HttpPost("{collectionName}/q")]
        public async Task<IActionResult> PostQuery(string collectionName, [FromBody] QueryDocument queryDocument)
        {
            if (string.IsNullOrWhiteSpace(collectionName))
                return BadRequest();

            var result = await dataService.ExecuteAsync(collectionName, queryDocument);

            return Ok(result);
        }

        [HttpPost("{collectionName}/a")]
        [HttpPost]
        public async Task<IActionResult> PostAggregation(string collectionName, [FromBody] AggregateDocument aggDocument)
        {
            if (string.IsNullOrWhiteSpace(collectionName))
                return BadRequest();

            var result = await dataService.ExecuteAsync(collectionName, aggDocument);
            return Ok(result);
        }
    }
}
