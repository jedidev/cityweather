using System;
using System.Collections.Generic;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using cityweather.Models;

namespace cityweather.Droid
{
    public class CitiesAdapter : RecyclerView.Adapter
    {

        private Context _context;

        public CitiesAdapter(Context context)
        {
            _context = context; 
        }


        public List<City> Cities { get; set; }

        public override int ItemCount => Cities != null ? Cities.Count : 0;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            CityViewHolder cityViewHolder = (CityViewHolder) holder;
            cityViewHolder.TextView.Text = Cities[position].Name;
            cityViewHolder.Context = _context;
            cityViewHolder.Id = Cities[position].Id;
            cityViewHolder.Name = Cities[position].Name;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = View.Inflate(parent.Context, Android.Resource.Layout.SimpleListItem1, null);
            CityViewHolder viewHolder = new CityViewHolder(view);
            return viewHolder;
        }
    }
}
