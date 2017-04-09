﻿namespace DataCat.Controllers
{
    using DataCat.Constants;
    using DataCat.Core.Entity;
    using DataCat.Core.Model;
    using DataCat.Core.Paging;
    using DataCat.Core.Services;
    using DataCat.Core.Utility;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
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
        [HttpGet(Name = RouteConstants.GetDataConnectionsRoute)]
        public async Task<IActionResult> Get(int page = 0, int pageSize = PagingConstants.MaxPageSize, bool envelope = true)
        {
            var total = service.Collection.Count(x => true);
            var result = await service.Collection
                .AsQueryable()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();

            if (envelope)
            {
                var pagedResult = new PageEnvelope<DataConnection>(
                    total, page, pageSize, RouteConstants.GetDataConnectionsRoute,
                    result, this.Request, this.Url);

                return Ok(pagedResult);
            }
            else
            {
                return Ok(result);
            }
        }

        [Authorize]
        [HttpGet("{id}", Name = RouteConstants.CreateDataConnectionRoute)]
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
            return Created(Url.Link(RouteConstants.CreateDataConnectionRoute, new { id = result.Id }), result);
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
        public async Task<IActionResult> UpdateResult([FromRoute]string id, [FromBody]DataConnectionModel model)
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
