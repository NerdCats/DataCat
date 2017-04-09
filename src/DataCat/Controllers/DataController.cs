namespace DataCat.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Core;
    using System.Threading.Tasks;
    using System.Reflection;
    using Microsoft.AspNetCore.Authorization;
    using DataCat.Core.Services;
    using DataCat.Core.Utility;

    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private IDataConnectionService connectionService;

        public DataController(IDataConnectionService connectionService)
        { 
            this.connectionService = connectionService;
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

        [Authorize]
        [HttpPost("{connection}/{collectionName}/q")]
        public async Task<IActionResult> PostQuery(string connection, string collectionName, [FromBody] QueryDocument queryDocument)
        {
            if (queryDocument == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            // ConnectionService needs to get connection based on username
            // We need to send back an unauthorized response if the user is not authorized to do this
            // Otherwise send bad request

            var connectionRef = await connectionService.Find(connection);
            if (connectionRef.User != User.GetUserId())
            {
                return Unauthorized();
            }

            var dataService = new DataService(connectionRef);
            var result = await dataService.ExecuteAsync(collectionName, queryDocument);

            return Ok(result);
        }

        [Authorize]
        [HttpPost("{connection}/{collectionName}/a")]
        [HttpPost]
        public async Task<IActionResult> PostAggregation(string connection, string collectionName, [FromBody] AggregateDocument aggDocument)
        {
            if (aggDocument == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var connectionRef = await connectionService.Find(connection);
            if (connectionRef.User != User.GetUserId())
            {
                return Unauthorized();
            }
            var dataService = new DataService(connectionRef);

            var result = await dataService.ExecuteAsync(collectionName, aggDocument);
            return Ok(result);
        }
    }
}
