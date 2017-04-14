namespace DataCat.Core.Model
{
    using DataCat.Core.Entity;
    using MongoDB.Bson;
    using MongoDB.Bson.IO;
    using Newtonsoft.Json.Linq;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class WidgetModel
    {
        public string Id { get; set; }
        public Filter Filter { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "FilterId is required")]
        public string FilterId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Connection is required")]
        public string ConnectionId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Collection name is required")]
        public string CollectionName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Widget type is required")]
        public string Type { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Data map is required")]
        public JObject DataMap { get; set; }

        public JObject Config { get; set; }

        public Widget ToEntity(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException(nameof(userId));

            var widgetEntity = new Widget()
            {
                FilterId = this.FilterId,
                CollectionName = this.CollectionName,
                Config = BsonDocument.Parse(this.Config.ToString()),
                ConnectionId = this.ConnectionId,
                DataMap = BsonDocument.Parse(this.DataMap.ToString()),
                Type = this.Type,
                User = userId
            };

            return widgetEntity;
        }

        public Widget ToEntity(string id, string userId)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException(nameof(id));

            var result = ToEntity(userId);
            result.Id = id;
            return result;
        }

        public static WidgetModel FromEntity(Widget widget)
        {
            return new WidgetModel()
            {
                Id = widget.Id,
                CollectionName = widget.CollectionName,
                Config = JObject.Parse(widget.Config.ToJson()),
                ConnectionId = widget.ConnectionId,
                DataMap = JObject.Parse(widget.DataMap.ToJson()),
                FilterId = widget.FilterId,
                Type = widget.Type
            };
        }

        public bool ShouldSerializeFilter()
        {
            return this.Filter != null;
        }

        public bool ShouldSerializeId()
        {
            return !string.IsNullOrWhiteSpace(this.Id);
        }
    }
}
