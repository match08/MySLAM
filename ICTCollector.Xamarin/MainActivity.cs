﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using ICTCollector.Xamarin.Helper;

namespace ICTCollector.Xamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            if (savedInstanceState == null)
            {
                FragmentManager.BeginTransaction().Replace(Resource.Id.container, CameraFragment.Instance).Commit();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.main_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_settings:
                    {
                        HelperManager.CameraHelper.State = CameraState.Close;
                        Intent i = new Intent(this, typeof(SettingsActivity));
                        break;
                    }
                default: break;
            }
            return base.OnOptionsItemSelected(item);
        }

    }
}