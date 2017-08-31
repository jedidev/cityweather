using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace cityweather.Droid
{
    public class CityViewHolder : RecyclerView.ViewHolder
    {
        public TextView TextView { get; private set; }

        public View ItemView { get; private set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public Context Context { get; set; }

        public CityViewHolder(View itemView) : base(itemView) {
            TextView = itemView.FindViewById<TextView>(Android.Resource.Id.Text1);
            ItemView = itemView;

            ItemView.Click += (sender, e) => {
                Intent intent = new Intent(Context, typeof(DetailActivity));
                intent.PutExtra(DetailActivity.ID_EXTRA, Id);
                intent.PutExtra(DetailActivity.NAME_EXTRA, Name);
                Context.StartActivity(intent);
            };
        }
    }
}
