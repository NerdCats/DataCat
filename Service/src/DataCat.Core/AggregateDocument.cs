using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DataCat.Core
{
    public class AggregateDocument
    {
        /// <summary>
        /// Mongodb aggregation pipeline to aggregate data from a collection
        /// </summary>
        public List<JObject> aggreagate { get; set; }
    }
}
