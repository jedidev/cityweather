using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace cityweather.Models
{
    public class WeatherReport
    {
        [JsonProperty("coord")]
        public Location Coordinates { get; set; }

        [JsonProperty("weather")]
		public List<Weather> Weathers { get; set; }

		[JsonProperty("main")]
		public Main Main { get; set; }
    }
}
