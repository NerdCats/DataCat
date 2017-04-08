namespace DataCat.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using DataCat.Core.Model;
    using DataCat.Core.Exception;
    using System.Net;
    using System;

    [Route("api/[controller]")]
    public class FilterController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Authorize]
        [HttpPost()]
        public void Post([FromBody]FilterModel model)
        {
            if (model == null || !ModelState.IsValid)
                throw new ApiException("Model error encountered", HttpStatusCode.BadRequest, ModelState);

            throw new NotImplementedException();
        }
    }
}
