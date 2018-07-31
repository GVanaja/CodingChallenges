using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLCodingChallenge.BusinessLayer
{
    [JsonObject]
    public class RoadDetails
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("statusSeverity")]
        public string StatusSevirity { get; set; }

        [JsonProperty("statusSeverityDescription")]
        public string StatusSevirityDescription { get; set; }

    }
}
