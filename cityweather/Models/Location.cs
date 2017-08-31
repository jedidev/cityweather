using Newtonsoft.Json;

namespace cityweather.Models
{
    public class Location
    {

        [JsonProperty("lon")]
        public double longitude { get; set; }

        [JsonProperty("lat")]
        public double latitude { get; set; }

    }
}
