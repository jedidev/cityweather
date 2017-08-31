using Foundation;
using System;
using UIKit;
using cityweather.Services;
using cityweather.Models;
using System.Threading.Tasks;

namespace cityweather.iOS
{
    public partial class DetailViewController : UIViewController
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

        public DetailViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.Title = CityName;

            WeatherService weatherService = new WeatherService();
            DownloadService downloadService = new DownloadService();

            Task.Run(async () => {

				WeatherReport weatherReport = await weatherService.RetrieveWeatherForCityIdAsync(CityId);

                if (weatherReport != null) {
                    String icon = weatherReport.Weathers[0].Icon;
                    String url = "http://openweathermap.org/img/w/" + icon + ".png";

                    byte[] imageBytes = await downloadService.DownloadItem(url);
                    NSData imageData = NSData.FromArray(imageBytes);

                    InvokeOnMainThread(() => {
                        IconImageView.ContentMode = UIViewContentMode.ScaleAspectFill;
						IconImageView.Image = UIImage.LoadFromData(imageData);

                        TemperatureLabel.Text = weatherReport.Main.TemperatureDegC + " deg C";
                        MinTempLabel.Text = weatherReport.Main.MinimumTemperatureDegC + " deg C";
                        MaxTempLabel.Text = weatherReport.Main.MaximumTemperatureDegC + " deg C";
                    });
                }
            });
        }
    }
}