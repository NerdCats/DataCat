namespace DataCat.Core.Entity
{
    using DataCat.Core.Db;
    using MongoDB.Bson.Serialization.Attributes;

    [BsonIgnoreExtraElements(true)]
    public class Filter: DbEntity
    {
        public string Name { get; set; }
        public string FilterString { get; set; }
        public string User { get; set; }
    }
}
