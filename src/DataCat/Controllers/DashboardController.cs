namespace DataCat.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using DataCat.Core.Services;
    using DataCat.Core.Entity;
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using MongoDB.Driver;
    using DataCat.Core.Utility;
    using DataCat.ActionFilter;
    using DataCat.Constants;
    using System.Threading.Tasks;
    using DataCat.Core.Exception;
    using System.Net;

    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        private IDashboardService service;

        public DashboardController(IDashboardService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet(Name = RouteConstants.DashboardBrowseRoute)]
        [Paginate]
        public IQueryable<Dashboard> Get()
        {
            return service.Collection.AsQueryable().Where(x => x.User == this.User.GetUserId());
        }

        [Authorize]
        [HttpGet("{id}", Name = RouteConstants.DashboardSelfRoute)]
        public async Task<IActionResult> Get(string id)
        {
            var result = await service.Find(id);
            if (result.User != this.User.GetUserId())
                return Unauthorized();

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Dashboard dashboard)
        {
            if (dashboard == null || !ModelState.IsValid)
                throw new ApiException("Model error encountered", HttpStatusCode.BadRequest, ModelState);

            dashboard.User = this.User.GetUserId();
            var result = await service.Create(dashboard);
            return Created(Url.Link(RouteConstants.DashboardSelfRoute, new { id = result.Id }), result);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]string id, [FromBody]Dashboard dash)
        {
            if (dash == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var dashboard = await service.Find(id);
            if (dashboard.User != this.User.GetUserId())
                return Unauthorized();

            dash.Id = id;

            var result = await service.Update(dash);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var dashboard = await service.Find(id);
            if (dashboard.User != this.User.GetUserId())
                return Unauthorized();

            var result = await service.Delete(id);
            return Ok(result);
        }
    }
}
