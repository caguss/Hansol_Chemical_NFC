﻿using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using System.Threading;

namespace Hansol_Chemical_NFC.Droid
{
    [Activity(Label = "한솔 환경안전", RoundIcon = "@mipmap/icon", Icon = "@mipmap/icon", /*RoundIcon = "@mipmap/CoReader_Icon_round", Icon = "@mipmap/CoReader_Icon"*/ Theme = "@style/SplashTheme", MainLauncher = true, NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Thread thread = new Thread(() =>
            {
                this.RunOnUiThread(() =>
                SimulateStartup());
            }
            );
            thread.Start();

        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
        }

        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }

        // Simulates background work that happens behind the splash screen
        private void SimulateStartup()
        {
            //await Task.Delay(1000); // Simulate a bit of startup work.
            //Thread.Sleep(100);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            Finish();
        }
    }

}