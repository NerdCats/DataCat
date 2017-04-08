namespace DataCat.Core.Services
{
    using DataCat.Core.Db;
    using DataCat.Core.Entity;
    using DataCat.Core.Exception;
    using MongoDB.Driver;
    using System;
    using System.Threading.Tasks;

    public class FilterService : IFilterService
    {
        public IMongoCollection<Filter> Collection { get; private set; }

        public FilterService(IDbContext dbContext)
        {
            this.Collection = dbContext.FilterConnection;
        }

        public async Task<Filter> Create(Filter filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            await this.Collection.InsertOneAsync(filter);
            return filter;
        }

        public async Task<Filter> Find(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException(nameof(id));

            var result = await this.Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (result == null)
                throw new EntityNotFoundException(typeof(DataConnection), id);

            return result;
        }

        public async Task<Filter> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException(nameof(id));

            var result = await this.Collection.FindOneAndDeleteAsync(x => x.Id == id);
            if (result == null)
                throw new EntityDeleteException(typeof(DataConnection), id);

            return result;
        }

        public async Task<Filter> Update(Filter filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            if (string.IsNullOrWhiteSpace(filter.Id))
                throw new ArgumentNullException(nameof(filter.Id));

            var result = await this.Collection.FindOneAndReplaceAsync(x => x.Id == filter.Id, filter);
            if (result == null)
                throw new EntityUpdateException(typeof(Filter), filter.Id);

            return result;
        }
    }
}
