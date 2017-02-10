namespace DataCat.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Core;

    [Route("api")]
    public class DataController : Controller
    {
        private IDbContext dbContext;

        public DataController(IDbContext dbContext)
        {
            this.dbContext = dbContext;
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
