using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DataCat.Core;

namespace DataCat.Controllers
{
    [Route("api")]
    public class DataController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "this is nice" };
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
