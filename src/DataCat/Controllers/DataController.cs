namespace DataCat.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Core;
    using Microsoft.Extensions.Options;
    using Lib.Settings;

    [Route("api")]
    public class DataController : Controller
    {
        private IOptions<DatabaseOptions> databaseOptionsAccessor;

        public DataController(IOptions<DatabaseOptions> databaseOptions)
        {
            this.databaseOptionsAccessor = databaseOptions;
        }

        [HttpPost("{collection}")]
        public IActionResult Post(string collection, [FromBody] QueryDocument query)
        {
            if (string.IsNullOrWhiteSpace(collection))
                return BadRequest();
            
            return Ok(query);
        }
    }
}
