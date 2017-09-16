using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace ExoPlayer.Forms.ViewModels
{
    public class MainPageViewModel:INotifyPropertyChanged
    {
        private string _videoSource;

        public MainPageViewModel()
        {
                LoadVideoCommand = new Command(LoadVideo);
        }
        public string VideoSource
        {
            get { return _videoSource; }
            set
            {
                _videoSource = value; 
                OnPropertyChanged();
            }
        }

        public Command LoadVideoCommand { get; set; }

        private void LoadVideo()
        {
            VideoSource = "http://www.sample-videos.com/video/mp4/240/big_buck_bunny_240p_50mb.mp4";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
