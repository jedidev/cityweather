using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace cityweather.Droid
{
    public class CityViewHolder : RecyclerView.ViewHolder
    {
        public TextView TextView { get; private set; }

        public CityViewHolder(View itemView) : base(itemView) {
            TextView = itemView.FindViewById<TextView>(Resource.Id.text);
        }
    }
}
