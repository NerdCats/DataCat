namespace DataCat.Core.Entity
{
    public class Widget
    {
        public string FilterId { get; set; }
        public string ConnectionId { get; set; }
        public string CollectionName { get; set; }
        public string Type { get; set; }
        public dynamic DataMap { get; set; }
        public dynamic Config { get; set; }
    }
}
