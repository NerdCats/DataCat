namespace DataCat.Core.Entity
{
    using MongoDB.Bson.Serialization.Attributes;

    public class DataConnection
    {
        [BsonId]
        public string Id { get; set; }
        public string ConnectionString { get; set; }
        public string Name { get; set; }
    }
}
