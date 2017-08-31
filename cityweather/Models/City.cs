using System;
using Newtonsoft.Json;

namespace cityweather.Models
{
    public class City
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
		public String Name { get; set; }

		//[JsonProperty("country")]
		//public String Country { get; set; }

		//[JsonProperty("coord")]
		//public Location Location { get; set; }
    }
}
