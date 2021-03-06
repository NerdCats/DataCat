﻿namespace DataCat.Controllers
{
    using DataCat.ActionFilter;
    using DataCat.Constants;
    using DataCat.Core.Entity;
    using DataCat.Core.Model;
    using DataCat.Core.Services;
    using DataCat.Core.Utility;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MongoDB.Driver;
    using System.Linq;
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
        [HttpGet(Name = RouteConstants.DataConnectionBrowseRoute)]
        [Paginate]
        public IQueryable<DataConnection> Get()
        {
            return service.Collection.AsQueryable().Where(x => x.User == this.User.GetUserId());
        }

        [Authorize]
        [HttpGet("{id}", Name = RouteConstants.DataConnectionSelfRoute)]
        public async Task<IActionResult> Get(string id)
        {
            var result = await service.Find(id);
            if (result.User != this.User.GetUserId())
                return Unauthorized();

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]DataConnectionModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.Create(model.ToEntity(this.User.GetUserId()));
            return Created(Url.Link(RouteConstants.DataConnectionSelfRoute, new { id = result.Id }), result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var connection = await service.Find(id);
            if (connection.User != this.User.GetUserId())
                return Unauthorized();

            // TODO: Deleting any connection like it doesn't matter.
            var result = await service.Delete(id);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]string id, [FromBody]DataConnectionModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var connection = await service.Find(id);
            if (connection.User != this.User.GetUserId())
                return Unauthorized();

            var result = await service.Update(model.ToEntity(id, this.User.GetUserId()));
            return Ok(result);
        }
    }
}
