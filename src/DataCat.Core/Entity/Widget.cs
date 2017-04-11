namespace DataCat.Core.Entity
{
    using DataCat.Core.Db;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    [BsonIgnoreExtraElements(true)]
    public class Widget : DbEntity
    {
        public string FilterId { get; set; }
        public string ConnectionId { get; set; }
        public string CollectionName { get; set; }
        public string Type { get; set; }
        public BsonDocument DataMap { get; set; }
        public BsonDocument Config { get; set; }
        public string User { get; set; }
    }
}
