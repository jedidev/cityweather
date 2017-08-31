
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using cityweather.Models;
using cityweather.Services;

namespace cityweather.Droid
{
    [Activity(Label = "DetailActivity")]
    public class DetailActivity : ActionBarActivity
    {
        public static string ID_EXTRA = "ID_EXTRA";
        public static string NAME_EXTRA = "NAME_EXTRA";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            int cityId = Intent.GetIntExtra(ID_EXTRA, 0);
            string cityName = Intent.GetStringExtra(NAME_EXTRA);

			// Create your application here
			SetContentView(Resource.Layout.Detail);
            Title = cityName;

            ImageView imageView = FindViewById<ImageView>(Resource.Id.image_view);
            TextView tempTextView = FindViewById<TextView>(Resource.Id.current_temperature);
            TextView minTempTextView = FindViewById<TextView>(Resource.Id.min_temp_text_view);
            TextView maxTempTextView = FindViewById<TextView>(Resource.Id.max_temp_text_view);

			WeatherService weatherService = new WeatherService();
			DownloadService downloadService = new DownloadService();

			Task.Run(async () => {

                WeatherReport weatherReport = await weatherService.RetrieveWeatherForCityIdAsync(cityId);

				if (weatherReport != null)
				{
					String icon = weatherReport.Weathers[0].Icon;
					String url = "http://openweathermap.org/img/w/" + icon + ".png";

					byte[] imageBytes = await downloadService.DownloadItem(url);
                    Bitmap bitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);

					RunOnUiThread(() => {
						imageView.SetImageBitmap(bitmap);

						tempTextView.Text = weatherReport.Main.TemperatureDegC + " deg C";
						minTempTextView.Text = weatherReport.Main.MinimumTemperatureDegC + " deg C";
						maxTempTextView.Text = weatherReport.Main.MaximumTemperatureDegC + " deg C";
                    });
				}
			});
        }
    }
}
