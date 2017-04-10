namespace DataCat.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using DataCat.Core.Model;
    using DataCat.Core.Exception;
    using System.Net;
    using DataCat.Core.Services;
    using System.Threading.Tasks;
    using DataCat.Core.Utility;
    using DataCat.Constants;
    using DataCat.Core.Entity;
    using System.Linq;
    using DataCat.ActionFilter;
    using MongoDB.Driver;

    [Route("api/[controller]")]
    public class FilterController : Controller
    {
        private IFilterService service;

        public FilterController(IFilterService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet(Name = RouteConstants.FilterBrowseRoute)]
        [Paginate]
        public IQueryable<Filter> Get()
        {
            return service.Collection.AsQueryable();
        }

        [Authorize]
        [HttpGet("{id}", Name = RouteConstants.FilterSelfRoute)]
        public async Task<IActionResult> Get(string id)
        {
            var result = await service.Find(id);
            if (result.User != this.User.GetUserId())
                return Unauthorized();
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]FilterModel model)
        {
            if (model == null || !ModelState.IsValid)
                throw new ApiException("Model error encountered", HttpStatusCode.BadRequest, ModelState);

            var result = await service.Create(model.ToEntity(this.User.GetUserId()));
            return Created(Url.Link(RouteConstants.FilterSelfRoute, new { id = result.Id }), result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var filter = await service.Find(id);
            if (filter.User != this.User.GetUserId())
                return Unauthorized();

            // TODO: Deleting any connection like it doesn't matter.
            var result = await service.Delete(id);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResult([FromRoute]string id, [FromBody]FilterModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var filter = await service.Find(id);
            if (filter.User != this.User.GetUserId())
                return Unauthorized();

            var result = await service.Update(model.ToEntity(id, this.User.GetUserId()));
            return Ok(result);
        }
    }
}
