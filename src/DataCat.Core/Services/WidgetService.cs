using DataCat.Core.Db;

namespace DataCat.Core.Services
{
    public class WidgetService
    {
        public WidgetService(IDbContext dbContext)
        {
            this.Collection = dbContext.WidgetCollection;
        }
    }
}
