using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using cityweather.Models;
using cityweather.Services;
using System.Linq;
using Android.Support.V7.App;

namespace cityweather.Droid
{
    [Activity(Label = "cityweather", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/MyTheme")]
    public class MainActivity : ActionBarActivity
    {
        private CityService _cityService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _cityService = CityService.GetSharedInstance();

            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.recycler_view); 
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            SearchView searchView = FindViewById<SearchView>(Resource.Id.search_view);

            CitiesAdapter adapter = new CitiesAdapter(this);
            recyclerView.SetAdapter(adapter);

            searchView.QueryTextChange += (sender, e) => {

				List<City> cities = _cityService.Cities;
                List<City> filteredCities = null;

                if (e.NewText.Length > 2 && cities != null)
				{
                    filteredCities = cities.Where(c => c.Name.ToLower().Contains(e.NewText.ToLower())).ToList();
				}
				else
				{
					filteredCities = null;
				}
                adapter.Cities = filteredCities;
                adapter.NotifyDataSetChanged();
			};
        }
    }
}

