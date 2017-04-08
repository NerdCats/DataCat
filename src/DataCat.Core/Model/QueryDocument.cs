namespace DataCat.Core
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;

    public class QueryDocument
    {
        /// <summary>
        /// Mongodb query object to query data from collection
        /// </summary>
        /// 
        [Required(AllowEmptyStrings = false, ErrorMessage = "Invalid/null query specification")]
        [JsonProperty("query")]
        public JObject Query { get; set; }

        /// <summary>
        /// Mongodb projection object to project data from the result
        /// </summary>
        [JsonProperty("project")]
        public JObject Project { get; set; }

        /// <summary>
        /// Mongodb sort operator
        /// </summary>
        [JsonProperty("sort")]
        public JObject Sort { get; set; }

        /// <summary>
        /// Mongodb skip variable to skip results
        /// </summary>
        [JsonProperty("skip")]
        public int Skip { get; set; } = 0;

        /// <summary>
        /// mongodb limit variable to limit results
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; } = 20;
    }
}
