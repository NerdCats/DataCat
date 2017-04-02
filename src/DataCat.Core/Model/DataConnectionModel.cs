namespace DataCat.Core.Model
{
    using DataCat.Core.Entity;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DataConnectionModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ConnectionString required")]
        public string ConnectionString { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name required")]
        public string Name { get; set; }

        public DataConnection ToEntity(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException(nameof(userId));

            var connectionEntity = new DataConnection()
            {
                ConnectionString = this.ConnectionString,
                Name = this.Name
            };
            return connectionEntity;
        }

        public DataConnection ToEntity(string id, string userId)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException(nameof(id));
            return ToEntity(userId);
        }
    }
}
