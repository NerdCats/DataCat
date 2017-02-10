using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace DataCat.Core
{
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
        /// Mongodb aggregation pipeline to aggregate data from a collection
        /// </summary>
        public List<JObject> aggreagate { get; set; }
    }
}
