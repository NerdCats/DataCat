namespace DataCat.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using DataCat.Core.Services;
    using Microsoft.AspNetCore.Authorization;
    using DataCat.Constants;
    using DataCat.ActionFilter;
    using MongoDB.Driver;
    using DataCat.Core.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using DataCat.Core.Utility;
    using DataCat.Core.Exception;
    using System.Net;
    using Newtonsoft.Json.Linq;
    using DataCat.Core.Model;

    [Route("api/[controller]")]
    public class WidgetController : Controller
    {
        private IWidgetService service;

        public WidgetController(IWidgetService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet(Name = RouteConstants.WidgetBrowseRoute)]
        [Paginate]
        public IQueryable<Widget> Get()
        {
            // Not sure to be honest, since this will serve out the entities, not the models, but meh..
            return service.Collection.AsQueryable();
        }


        [Authorize]
        [HttpGet("{id}", Name = RouteConstants.WidgetSelfRoute)]
        public async Task<IActionResult> Get(string id)
        {
            var result = await service.Find(id);
            if (result.User != this.User.GetUserId())
                return Unauthorized();

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]WidgetModel widget)
        {
            if (widget == null || !ModelState.IsValid)
                throw new ApiException("Model error encountered", HttpStatusCode.BadRequest, ModelState);

            var result = await service.Create(widget.ToEntity(this.User.GetUserId()));
            return Created(Url.Link(RouteConstants.WidgetSelfRoute, new { id = result.Id }), result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]string id, [FromBody]WidgetModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var widget = await service.Find(id);
            if (widget.User != this.User.GetUserId())
                return Unauthorized();

            // INFO: I know this is bad, may be the model should have id's anyway.
            var result = await service.Update(model.ToEntity(id, this.User.GetUserId()));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var widget = await service.Find(id);
            if (widget.User != this.User.GetUserId())
                return Unauthorized();

            var result = await service.Delete(id);
            return Ok(result);
        }
    }
}
