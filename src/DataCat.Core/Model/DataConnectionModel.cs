namespace DataCat.Core.Model
{
    using System.ComponentModel.DataAnnotations;
    public class DataConnectionModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ConnectionString required")]
        public string ConnectionString { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name required")]
        public string Name { get; set; }
    }
}
