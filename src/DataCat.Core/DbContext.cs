using MongoDB.Driver;

namespace DataCat.Core
{
    public class DbContext
    {
        private MongoClient mongoClient;
        public IMongoDatabase Database { get; private set; }

        public DbContext()
        {
            
        }
    }
}
