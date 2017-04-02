namespace DataCat.Controllers
{
    using DataCat.Core.Model;
    using DataCat.Core.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class DataConnectionController : Controller
    {
        private IDataConnectionService service;

        public DataConnectionController(IDataConnectionService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await service.Find(id);
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]DataConnectionModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.Create(model.ToEntity(this.User.Identity.Name));
            // TODO: Should send back a Creted response
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await service.Delete(id);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResult([FromRoute]string id, [FromBody]DataConnectionModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.Update(model.ToEntity(id, this.User.Identity.Name));
            return Ok(result);
        }
    }
}
