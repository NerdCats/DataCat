namespace DataCat.Core.Services
{
    using DataCat.Core.Db;
    using DataCat.Core.Entity;
    using DataCat.Core.Exception;
    using MongoDB.Driver;
    using System;
    using System.Net;
    using System.Threading.Tasks;

    public class WidgetService : IWidgetService
    {
        public IMongoCollection<Widget> Collection { get; private set; }
        public IDataConnectionService DataConnectionService { get; private set; }
        public IFilterService FilterService { get; private set; }

        public WidgetService(
            IDbContext dbContext, 
            IDataConnectionService dataConnectionService,
            IFilterService filterService)
        {
            this.Collection = dbContext.WidgetCollection;
            this.DataConnectionService = dataConnectionService;
            this.FilterService = filterService;
        }

        public async Task<Widget> Create(Widget widget)
        {
            if (widget == null)
                throw new ArgumentNullException(nameof(widget));

            await Validate(widget);

            await this.Collection.InsertOneAsync(widget);
            return widget;
        }

        private async Task Validate(Widget widget)
        {
            // this looks stupid, but I dont have any other way to validate
            var connection = await this.DataConnectionService.Find(widget.ConnectionId);
            if (connection.User != widget.User)
                throw new ApiException("Not authorized to create widget, the connection doesn't belong to the same user", HttpStatusCode.Unauthorized);

            var filter = await this.FilterService.Find(widget.FilterId);
            if (filter.User != widget.User)
                throw new ApiException("Not authorized to create widget, the filter doesn't belong to the same user", HttpStatusCode.Unauthorized);
        }

        public async Task<Widget> Find(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException(nameof(id));

            var result = await this.Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (result == null)
                throw new EntityNotFoundException(typeof(Widget), id);

            return result;
        }

        public async Task<Widget> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException(nameof(id));

            var result = await this.Collection.FindOneAndDeleteAsync(x => x.Id == id);
            if (result == null)
                throw new EntityDeleteException(typeof(Widget), id);

            return result;
        }

        public async Task<Widget> Update(Widget widget)
        {
            if (widget == null)
                throw new ArgumentNullException(nameof(widget));

            if (string.IsNullOrWhiteSpace(widget.Id))
                throw new ArgumentNullException(nameof(widget.Id));

            await Validate(widget);

            var result = await this.Collection.FindOneAndReplaceAsync(x => x.Id == widget.Id, widget);
            if (result == null)
                throw new EntityUpdateException(typeof(Widget), widget.Id);

            return result;
        }
    }
}
