namespace DataCat.Controllers
{
    using DataCat.Core.Model;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Route("api/[controller]")]
    public class DataConnectionController : Controller
    {
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody]DataConnectionModel model)
        {
            throw new NotImplementedException();
        }
    }
}
