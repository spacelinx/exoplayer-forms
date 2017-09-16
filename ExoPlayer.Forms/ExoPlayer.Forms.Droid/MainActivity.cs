using Android.App;
using Android.Content.PM;
using Android.OS;
using ExoPlayer.Forms.Droid.Resources;

namespace ExoPlayer.Forms.Droid
{
    [Activity(Label = "ExoPlayer.Forms", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            var application = new App();
            LoadApplication(application);
        }
    }
}

