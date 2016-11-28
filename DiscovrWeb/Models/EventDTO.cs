using Newtonsoft.Json;
using System;

namespace DiscovrWeb.Models
{
    public class EventDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }
    }
}