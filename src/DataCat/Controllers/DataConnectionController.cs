namespace DataCat.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class DataConnectionController : Controller
    {
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Secured endpoint");
        }
    }
}
