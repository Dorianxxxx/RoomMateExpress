﻿using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using RoomMateExpress.Core.ViewModels;

namespace RoomMateExpress.Droid.Views
{
    [Activity(Theme = "@style/RoomMateExpressTheme")]
    public class SettingsView : MvxAppCompatActivity<SettingsViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.settings_view);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            if (toolbar != null)
            {
                toolbar.InflateMenu(Resource.Menu.settings_menu);
                toolbar.MenuItemClick += async (sender, args) =>
                {
                    if (args.Item.ItemId == Resource.Id.save)
                    {
                        await ViewModel.SaveChangesCommand.ExecuteAsync();
                    }
                };
                toolbar.NavigationClick += (sender, args) =>
                {
                    OnBackPressed();
                };
            }
        }
    }
}