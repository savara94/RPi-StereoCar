using Plugin.Toast;
using RpiCarMobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RpiCarMobile.ViewModels
{
    public class ConfigurationViewModel : INotifyPropertyChanged
    {
        private string mIpAddress;
        public string IpAdress { get => mIpAddress; set { mIpAddress = value; OnPropertyChanged(nameof(IpAdress)); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ApplyCommand { get; set; }

        public ConfigurationViewModel()
        {
            ApplyCommand = new Command(CheckIpAdress);
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void CheckIpAdress(object obj)
        {
            CrossToastPopUp.Current.ShowToastMessage(IpAdress);
        }
    }
}
