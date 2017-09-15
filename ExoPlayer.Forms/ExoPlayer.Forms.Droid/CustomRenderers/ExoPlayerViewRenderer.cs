using System;
using System.ComponentModel;
using Afaq.IPTV.Droid.Players.ExoPlayer;
using Android.Views;
using Com.Google.Android.Exoplayer.Util;
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
        private VideoPlayer _player;
        private Android.Net.Uri _uri;

        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public void Init()
        {

        }



        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
 
            var player = Element as Views.ExoPlayer;

            if ((player != null) && (e.OldElement == null))
            {
                var metrics = Resources.DisplayMetrics;

                player.HeightRequest = metrics.WidthPixels / metrics.Density / player.VideoScale;


            }
        }

        private void OnRelease(object sender, EventArgs e)
        {
            _player.Release();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _player.Release();
            _player.Dispose();
            GC.Collect();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "VideoSource")
            {

                _uri = Android.Net.Uri.Parse(((Views.ExoPlayer)sender).VideoSource);

                InitializePlayer();
            }

        }

        private void InitializePlayer()
        {
            if (_player != null)
            {
                _player.Release();
                _player.Dispose();
            }

            SurfaceView surfaceView = new SurfaceView(Context);
            _player = new VideoPlayer(GetRendererBuilder(_uri), Context);
            _player.RefreshPlayer += _player_RefreshPlayer;
            _player.Prepare();
            _player.PlayWhenReady = true;
            _player.Surface = surfaceView.Holder.Surface;

            SetNativeControl(surfaceView);
        }

        private void _player_RefreshPlayer(object sender, EventArgs e)
        {
            var player = (VideoPlayer)sender;
            player.RefreshPlayer -= _player_RefreshPlayer;

            InitializePlayer();
        }

        private VideoPlayer.IRendererBuilder GetRendererBuilder(Android.Net.Uri uri)
        {
            var userAgent = ExoPlayerUtil.GetUserAgent(Context, "ExoPlayerDemo");
            return new ExtractorRendererBuilder(Context, userAgent, uri);
        }
    }
}