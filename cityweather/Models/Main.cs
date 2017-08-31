using System;
using Newtonsoft.Json;

namespace cityweather.Models
{
    public class Main
    {
        private static Double AbsoluteZero = -273.0;

		[JsonProperty("temp")]
        public Double Temperature { get; set; }

		[JsonProperty("humidity")]
		public int Humidity { get; set; }

		[JsonProperty("pressure")]
		public Double Pressure { get; set; }

		[JsonProperty("temp_min")]
		public Double MinimumTemperature { get; set; }

		[JsonProperty("temp_max")]
		public Double MaximumTemperature { get; set; }

		[JsonProperty("sea_level")]
		public Double SeaLevelPressure { get; set; }

        [JsonProperty("grnd_level")]
        public Double GroundLevelPressure { get; set; }

        [JsonIgnore]
        public Double TemperatureDegC 
        {
            get {
                return Temperature + AbsoluteZero;
            }
		}

		[JsonIgnore]
		public Double MinimumTemperatureDegC
		{
			get
			{
                return MinimumTemperature + AbsoluteZero;
			}
		}

		[JsonIgnore]
		public Double MaximumTemperatureDegC
		{
			get
			{
                return MaximumTemperature + AbsoluteZero;
			}
		}
    }
}
