using Android.Graphics;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RpiCarMobile.ViewModels
{
    public class StreamViewModel : INotifyPropertyChanged
    {
        private string mLeftCameraURI;
        public string LeftCameraURI { get => mLeftCameraURI; set { mLeftCameraURI = value; OnPropertyChanged(nameof(LeftCameraURI)); } }

        private string mRightCameraURI;
        public string RightCameraURI { get => mRightCameraURI; set { mRightCameraURI = value; OnPropertyChanged(nameof(RightCameraURI)); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand MoveCommand { private set; get; }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public StreamViewModel()
        {
            RightCameraURI = $"http://www.washingtonpost.com/resizer/JEQO2f_87x9Df64ccwinuQnaiwg=/1440x0/smart/arc-anglerfish-washpost-prod-washpost.s3.amazonaws.com/public/7KUG66GEHUI6TC7XZXRNTYEQKU.jpg";
            LeftCameraURI = $"http://cdn.cnn.com/cnnnext/dam/assets/191024091949-02-foster-cat-exlarge-169.jpg";

            MoveCommand = new Command(Move);            
        }

        private void Move(object direction)
        {
            CrossToastPopUp.Current.ShowToastMessage((string)direction);
        }
    }
}
