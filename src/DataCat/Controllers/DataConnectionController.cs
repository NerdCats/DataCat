namespace DataCat.Controllers
{
    using DataCat.Constants;
    using DataCat.Core.Exception;
    using DataCat.Core.Model;
    using DataCat.Core.Services;
    using DataCat.Core.Utility;
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
        [HttpGet("{id}", Name = RouteConstants.CreateDataConnectionRoute)]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var result = await service.Find(id);
                return Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]DataConnectionModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.Create(model.ToEntity(this.User.GetUserId()));
            return Created(Url.Link(RouteConstants.CreateDataConnectionRoute, new { id = result.Id }), result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var result = await service.Delete(id);
                return Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResult([FromRoute]string id, [FromBody]DataConnectionModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.Update(model.ToEntity(id, this.User.GetUserId()));
            return Ok(result);
        }
    }
}
