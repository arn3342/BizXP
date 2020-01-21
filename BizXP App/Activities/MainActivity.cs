using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content.PM;
using Android.Content;

namespace BizXP_App.Activities
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Theme = "@style/Theme.AppBlueTheme", WindowSoftInputMode = Android.Views.SoftInput.AdjustPan, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        private Button inventoryBtn, orderBtn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            inventoryBtn = FindViewById<Button>(Resource.Id.inventoryBtn);
            orderBtn = FindViewById<Button>(Resource.Id.ordersBtn);
            inventoryBtn.Click += InventoryBtn_Click;
            orderBtn.Click += OrderBtn_Click;
        }

        private void OrderBtn_Click(object sender, System.EventArgs e)
        {
            Intent orderActivity = new Intent(this, typeof(OrderActivity));
            StartActivity(orderActivity);
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