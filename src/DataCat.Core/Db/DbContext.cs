namespace DataCat.Core.Db
{
    using MongoDB.Driver;
    using System;
    using DataCat.Core.Entity;

    public class DbContext: IDbContext
    {
        private MongoClient mongoClient;
        public IMongoDatabase Database { get; private set; }

        public IMongoCollection<DataConnection> DataConnectionCollection { get; private set; }
        public IMongoCollection<Filter> FilterConnection { get; private set; }

        public DbContext(string connectionString, string databaseName)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException($"{nameof(connectionString)} is null or whitespace");

            if (string.IsNullOrWhiteSpace(databaseName))
                throw new ArgumentException($"{nameof(databaseName)} is null or whitespace");

            var mongoUrlBuilder = new MongoUrlBuilder(connectionString);
            mongoClient = new MongoClient(mongoUrlBuilder.ToMongoUrl());

            Database = mongoClient.GetDatabase(databaseName);

            InitiateDataCatCollections();
            InitiateIndexes();
        }

        private void InitiateDataCatCollections()
        {
            DataConnectionCollection = Database.GetCollection<DataConnection>(CollectionNames.DataConnectionCollection);
            FilterConnection = Database.GetCollection<Filter>(CollectionNames.FilterConnection);
        }

        private void InitiateIndexes()
        {
            var indexOptions = new CreateIndexOptions();
            indexOptions.Unique = true;

            DataConnectionCollection.Indexes.CreateOne(Builders<DataConnection>.IndexKeys.Ascending(x => x.Name), indexOptions);
        }
    }
}
