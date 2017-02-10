using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DataCat.Core;

namespace DataCat.Controllers
{
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public void Post([FromBody] QueryDocument query)
        {
           
        }
    }
}
