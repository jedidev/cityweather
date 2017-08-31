using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using cityweather.Models;
using Newtonsoft.Json;

namespace cityweather.Services
{
    public class CityService
    {
		private static string cityJsonFile = "cityweather.Resources.cities.json";

		private static CityService _sharedInstance;

        public static CityService GetSharedInstance()
        {
            if (_sharedInstance == null)
            {
                _sharedInstance = new CityService();
            }
            return _sharedInstance;
        }

        public List<City> Cities { get; private set; }

        public bool DataAvailable { get; private set; }

        private CityService() 
        {
            DataAvailable = false;
            Task.Run(() => LoadCities());
        }

        private void LoadCities() {

            var assembly = typeof(CityService).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(cityJsonFile);
			string text = "";
			using (var reader = new System.IO.StreamReader(stream))
			{
                text = reader.ReadToEnd();
			}

            Cities = JsonConvert.DeserializeObject<List<City>>(text);
            DataAvailable = true;
        }
    }
}
