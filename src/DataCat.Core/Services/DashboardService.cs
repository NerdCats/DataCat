namespace DataCat.Core.Services
{
    using DataCat.Core.Db;
    using DataCat.Core.Entity;
    using DataCat.Core.Exception;
    using MongoDB.Driver;
    using System;
    using System.Threading.Tasks;

    public class DashboardService : IDashboardService
    {
        public IMongoCollection<Dashboard> Collection { get; private set; }

        public DashboardService(IDbContext dbContext)
        {
            this.Collection = dbContext.DashboardCollection;
        }

        public async Task<Dashboard> Create(Dashboard dashboard)
        {
            if (dashboard == null)
                throw new ArgumentNullException(nameof(dashboard));

            await this.Collection.InsertOneAsync(dashboard);
            return dashboard;
        }

        public async Task<Dashboard> Find(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException(nameof(id));

            var result = await this.Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (result == null)
                throw new EntityNotFoundException(typeof(Dashboard), id);

            return result;
        }

        public async Task<Dashboard> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException(nameof(id));

            var result = await this.Collection.FindOneAndDeleteAsync(x => x.Id == id);
            if (result == null)
                throw new EntityDeleteException(typeof(Dashboard), id);

            return result;
        }

        public async Task<Dashboard> Update(Dashboard dashboard)
        {
            if (dashboard == null)
                throw new ArgumentNullException(nameof(dashboard));

            if (string.IsNullOrWhiteSpace(dashboard.Id))
                throw new ArgumentNullException(nameof(dashboard.Id));

            var result = await this.Collection.FindOneAndReplaceAsync(x => x.Id == dashboard.Id, dashboard);
            if (result == null)
                throw new EntityUpdateException(typeof(Dashboard), dashboard.Id);

            return result;
        }
    }
}
