namespace DataCat.Core.Entity
{
    using DataCat.Core.Db;
    using MongoDB.Bson.Serialization.Attributes;

    [BsonIgnoreExtraElements(true)]
    public class DataConnection : DbEntity
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }

        public DataConnection() { }
    }
}
