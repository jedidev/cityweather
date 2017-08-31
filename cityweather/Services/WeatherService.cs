using System;
using System.Net.Http;
using System.Threading.Tasks;
using cityweather.Models;
using Newtonsoft.Json;

namespace cityweather.Services
{
    public class WeatherService
    {
        public async Task<WeatherReport> RetrieveWeatherForCityIdAsync(int cityId) {

            using (HttpClient client = new HttpClient())
            {
                var queryString = "?id=" + cityId.ToString() + "&APPID=" + Strings.ApiKey;

                using (var response = await client.GetAsync(Strings.BaseUrl + queryString))
                {
                    try
                    {
                        String weatherReportJson = await response.Content.ReadAsStringAsync();
                        WeatherReport report = JsonConvert.DeserializeObject<WeatherReport>(weatherReportJson);

                        return report;
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
            }
        }
    }
}
