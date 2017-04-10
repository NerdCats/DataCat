namespace DataCat.Core.Entity
{
    using DataCat.Core.Db;
    using MongoDB.Bson.Serialization.Attributes;
    using System.ComponentModel.DataAnnotations;

    [BsonIgnoreExtraElements(true)]
    public class Widget : DbEntity
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "FilterId is required")]
        public string FilterId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Connection is required")]
        public string ConnectionId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Collection name is required")]
        public string CollectionName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Widget type is required")]
        public string Type { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Data map is required")]
        public dynamic DataMap { get; set; }

        public dynamic Config { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "User id is required")]
        public string User { get; set; }
    }
}
