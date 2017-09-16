using System;
using System.ComponentModel;
using Android.App;
using Android.Views;
using ExoPlayer.Forms.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Xamarin.Forms.View;

[assembly: ExportRenderer(typeof(ExoPlayer.Forms.Views.ExoPlayer), typeof(ExoPlayerViewRenderer))]

namespace ExoPlayer.Forms.Droid.CustomRenderers
{
    /// <summary>
    /// CrossVideoPlayer Renderer for Android.
    /// </summary>
    public class ExoPlayerViewRenderer : ViewRenderer
    {
        private Android.Net.Uri _uri;
        private Android.Views.View _view;

        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public void Init()
        {

        }  

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            var activity = this.Context as Activity;
            _view = activity.LayoutInflater.Inflate(Resource.Layout.playeractivity, this, false);

            AddView(_view);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "VideoSource")
            {

//                _uri = Android.Net.Uri.Parse(((Views.ExoPlayer)sender).VideoSource);

            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);
            _view.Measure(msw, msh);
            _view.Layout(0, 0, r - l, b - t);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
//            _player.Release();
//            _player.Dispose();
            GC.Collect();
        }
    }
}