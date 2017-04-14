namespace DataCat.Core.Entity
{
    using DataCat.Core.Db;
    using DataCat.Core.Model;
    using MongoDB.Bson.Serialization.Attributes;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [BsonIgnoreExtraElements(true)]
    public class Dashboard: DbEntity
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title missing in model")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Widgets missing in model")]
        public List<DashboardWidget> Widgets { get; set; }

        public string User { get; set; }
    }
}
