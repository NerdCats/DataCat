namespace DataCat.Core.Services
{
    using DataCat.Core.Db;
    using DataCat.Core.Entity;
    using DataCat.Core.Exception;
    using MongoDB.Driver;
    using System;
    using System.Threading.Tasks;

    public class WidgetService : IWidgetService
    {
        public IMongoCollection<Widget> Collection { get; private set; }
        public WidgetService(IDbContext dbContext)
        {
            this.Collection = dbContext.WidgetCollection;
        }

        public async Task<Widget> Create(Widget widget)
        {
            if (widget == null)
                throw new ArgumentNullException(nameof(widget));

            // INFO: Do we need to validate a widget? May be. May be not. Skipping it now

            await this.Collection.InsertOneAsync(widget);
            return widget;
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

            var result = await this.Collection.FindOneAndReplaceAsync(x => x.Id == widget.Id, widget);
            if (result == null)
                throw new EntityUpdateException(typeof(Widget), widget.Id);

            return result;
        }
    }
}
