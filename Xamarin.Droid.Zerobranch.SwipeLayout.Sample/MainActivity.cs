using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using AndroidX.AppCompat.App;

namespace Nivaes.Zerobranch.SwipeLayout.Droid
{
    [Activity(Label = "@string/app_name",
        MainLauncher = true,
        Theme = "@style/AppTheme",
        Icon = "@mipmap/ic_launcher")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            base.SetContentView(Resource.Layout.activity_main);
            //base.FindViewById<View>(Resource.Id.left).Click += (s, o)=>
            //{
            //    base.StartActivity(new Intent(base.GetBaseContext(), LeftActivity.class));
            //};


            base.FindViewById<View>(Resource.Id.right).Click += (s, o)=>
            {
                base.StartActivity(new Intent(base.BaseContext, typeof(HorizontalActivity)));
            };

            base.FindViewById<View>(Resource.Id.horizontal).Click += (s, o) =>
            {
                base.StartActivity(new Intent(base.BaseContext, typeof(HorizontalActivity)));
            };
        }
    }
}


