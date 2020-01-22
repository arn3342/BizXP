using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content.PM;
using Android.Content;
using Android.Support.Constraints;
using System;
using BizXP_App.CustomViews;
using BizXP_App.Models;

namespace BizXP_App.Activities
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Theme = "@style/Theme.AppBlueTheme", WindowSoftInputMode = Android.Views.SoftInput.AdjustPan, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        private LinearLayout homeButtonContainer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            homeButtonContainer = this.FindViewById<LinearLayout>(Resource.Id.homeButtonContainer);
            GenerateMenuButtons();
        }

        private void GenerateMenuButtons()
        { 
            HomeButtonModel[] homeButtons = new HomeButtonModel[] 
            {
                new HomeButtonModel( ){ drawable =  Resource.Drawable.inventory_icon, title = "Inventory", desc = "Manage your products &amp; stocks" },
                new HomeButtonModel( ){ drawable =  Resource.Drawable.taka_green, title = "Orders &amp; Payments", desc = "Manage your orders &amp; payments" },
                new HomeButtonModel( ){ drawable =  Resource.Drawable.client_icon_blue, title = "Clients &amp; customers", desc = "Manage your beloved clients" },
            };

            for (int i=0; i < homeButtons.Length; i++)
            {
                HomeButton btn = new HomeButton(this);
                btn.SetContents(homeButtons[i]);
                homeButtonContainer.AddView(btn);
            }
        }

        private void OrderBtn_Click(object sender, System.EventArgs e)
        {
            Intent inventoryIntent = new Intent(this, typeof(OrderActivity));
            StartActivity(inventoryIntent);
        }

        private void InventoryBtn_Click(object sender, System.EventArgs e)
        {
            Intent inventoryIntent = new Intent(this, typeof(InventoryActivity));
            StartActivity(inventoryIntent);
        }

        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        
        
    }
}