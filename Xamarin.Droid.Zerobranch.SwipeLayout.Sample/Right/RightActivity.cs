namespace Nivaes.Zerobranch.SwipeLayout.Droid
{
    using System.Collections.Generic;
    using Android.App;
    using Android.OS;
    using AndroidX.AppCompat.App;
    using AndroidX.RecyclerView.Widget;

    [Activity(Theme = "@style/AppTheme")]
    public class RightActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            base.SetContentView(Resource.Layout.activity_right);

            var recyclerView = base.FindViewById<RecyclerView>(Resource.Id.recycler_view);
            recyclerView.SetAdapter(new RightAdapter(GetItems()));
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));
        }

        private List<string> GetItems()
        {
            List<string> items = new List<string>();
            for (int i = 0; i < 8; i++)
            {
                items.Add("item " + i);
            }
            return items;
        }
    }
}


