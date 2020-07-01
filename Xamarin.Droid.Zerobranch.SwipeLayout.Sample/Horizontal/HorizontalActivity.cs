namespace Nivaes.Zerobranch.SwipeLayout.Droid
{
    using System.Collections.Generic;
    using Android.App;
    using Android.OS;
    using AndroidX.AppCompat.App;
    using AndroidX.RecyclerView.Widget;

    [Activity(Label = "@string/app_name",
        MainLauncher = true,
        Theme = "@style/AppTheme",
        Icon = "@mipmap/ic_launcher")]
    public class HorizontalActivity : AppCompatActivity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);

            base.OnCreate(savedInstanceState);

            base.SetContentView(Resource.Layout.activity_horizontal);

            var recyclerView = base.FindViewById<RecyclerView>(Resource.Id.recycler_view);
            recyclerView.SetAdapter(new HorizontalAdapter(GetItems()));
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));
        }

        private List<string> GetItems()
        {
            List<string> items = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                items.Add("item " + i);
            }
            return items;
        }
    }
}


