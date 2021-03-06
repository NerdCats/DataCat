﻿namespace DataCat.Core.Model
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

        public string FilterType { get; set; } = FilterTypes.Query;

        public Filter ToEntity(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException(nameof(userId));

            var filterEntity = new Filter()
            {
                FilterString = this.FilterString,
                Name = this.Name,
                User = userId,
                FilterType = this.FilterType
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
    }
}
