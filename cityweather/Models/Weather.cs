using System;
using Newtonsoft.Json;

namespace cityweather.Models
{
    public class Weather
    {
        [JsonProperty("id")]
        public int Id { get; set; }

		[JsonProperty("description")]
		public String Description { get; set; }

		[JsonProperty("icon")]
		public String Icon { get; set; }
    }
}
