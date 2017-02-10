namespace DataCat.Core.Converters
{
    using System;
    using Newtonsoft.Json;
    using MongoDB.Bson;

    public class BsonDocumentConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(BsonDocument);
        }

        public override bool CanRead
        {
            get
            {
                return false; // Currently this is only for writing out BSONDocuments
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.DateFormatHandling = DateFormatHandling.IsoDateFormat;

            var result = value as BsonDocument;
            var jsonResult = result.ToJson(new MongoDB.Bson.IO.JsonWriterSettings()
            {
                OutputMode = MongoDB.Bson.IO.JsonOutputMode.Strict,
                Indent = true
            });

            writer.WriteRawValue(jsonResult);
        }
    }
}
