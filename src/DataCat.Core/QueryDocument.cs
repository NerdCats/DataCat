namespace DataCat.Core
{
    using System.Collections.Generic;
    using Newtonsoft.Json.Linq;

    public class QueryDocument
    {
        /// <summary>
        /// Mongodb query object to query data from collection
        /// </summary>
        public JObject query { get; set; }

        /// <summary>
        /// Mongodb projection object to project data from the result
        /// </summary>
        public JObject project { get; set; }

        /// <summary>
        /// Mongodb sort operator
        /// </summary>
        public JObject sort { get; set; }

        /// <summary>
        /// Mongodb skip variable to skip results
        /// </summary>
        public int skip { get; set; } = 0;

        /// <summary>
        /// mongodb limit variable to limit results
        /// </summary>
        public int limit { get; set; } = 20;

        /// <summary>
        /// Mongodb aggregation pipeline to aggregate data from a collection
        /// </summary>
        public List<JObject> aggreagate { get; set; }
    }
}
