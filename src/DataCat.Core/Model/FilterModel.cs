namespace DataCat.Core.Model
{
    using DataCat.Core.Entity;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FilterModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Missing the filter string in the model")]
        public string FilterString { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Missing the filter name in the model")]
        public string Name { get; set; }

        public Filter ToEntity(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException(nameof(userId));

            var filterEntity = new Filter()
            {
                FilterString = NormalizeFilter(this.FilterString),
                Name = this.Name,
                User = userId
            };

            return filterEntity;
        }

        public Filter ToEntity(string id, string userId)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException(nameof(id));

            var result = ToEntity(userId);
            result.Id = id;
            return result;
        }

        private string NormalizeFilter(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                throw new ArgumentException(nameof(filter));

            var normalizedFilter = filter
                .Replace("$", "_$")
                .Replace(".", "#");

            return normalizedFilter;
        }
    }
}
