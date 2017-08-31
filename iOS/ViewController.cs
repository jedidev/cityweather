using Foundation;
using System;
using UIKit;
using cityweather.Services;
using cityweather.Models;
using System.Collections.Generic;
using System.Linq;

namespace cityweather.iOS
{
    public partial class ViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate
    {
        private CityService _cityService;
        private List<City> _filteredCities;

        private int _selectedCityId;
        private string _selectedCityName;

        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _cityService = CityService.GetSharedInstance();

            NavigationItem.Title = "City Weather";

            CityTableView.DataSource = this;
            CityTableView.Delegate = this;

            SearchBar.TextChanged += (sender, e) => {

				List<City> cities = _cityService.Cities;

                if (e.SearchText.Length > 2 && cities != null) {
                    _filteredCities = cities.Where(c => c.Name.ToLower().Contains(e.SearchText.ToLower())).ToList();
                } else {
                    _filteredCities = null;
				}
				CityTableView.ReloadData();
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public nint RowsInSection(UITableView tableView, nint section)
        {
            return _filteredCities != null ? _filteredCities.Count() : 0;
        }

        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = CityTableView.DequeueReusableCell("city");
            if (cell == null) {
                cell = new UITableViewCell();
            }
            City filteredCity = _filteredCities[indexPath.Row];
            cell.TextLabel.Text = filteredCity.Name;

            return cell;
        }

        [Export("tableView:didSelectRowAtIndexPath:")]
        public void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            _selectedCityId = _filteredCities[indexPath.Row].Id;
            _selectedCityName = _filteredCities[indexPath.Row].Name;

            PerformSegue("ShowWeatherDetail", this);
            _filteredCities = null;
            SearchBar.Text = string.Empty;
            CityTableView.ReloadData();
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            if (segue.Identifier.Equals("ShowWeatherDetail")) {
                DetailViewController detailViewController = (DetailViewController) segue.DestinationViewController;
                detailViewController.CityId = _selectedCityId;
                detailViewController.CityName = _selectedCityName;
            }
        }
    }
}