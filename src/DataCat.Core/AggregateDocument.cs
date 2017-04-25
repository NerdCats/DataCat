namespace DataCat.Core
{
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AggregateDocument 
    {
        /// <summary>
        /// Mongodb aggregation pipeline to aggregate data from a collection
        /// </summary>
        ///  
        [Required(AllowEmptyStrings = false, ErrorMessage = "Invalid/null aggregate specification")]
        public List<JObject> aggregate { get; set; }

        /// <summary>
        /// Mongodb skip variable to skip results
        /// </summary>
        public int skip { get; set; } = 0;

        /// <summary>
        /// mongodb limit variable to limit results
        /// </summary>
        public int limit { get; set; } = 20;
    }
}
