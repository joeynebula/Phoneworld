﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Plugin.Permissions;

namespace Phoneword.Droid
{
    [Activity(Label = "Phoneword", Icon = "@drawable/xamarin_logo", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }
        readonly string PermissionsCall = Android.Manifest.Permission.CallPhone;
        const int RequestCallsId = 0;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, bundle);

            base.OnCreate(bundle);

            Instance = this;
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }


}