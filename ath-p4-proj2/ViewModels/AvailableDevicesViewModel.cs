using ath_p4_proj2.Models;
using System.Collections.Generic;


namespace ath_p4_proj2.ViewModels
{
    internal class AvailableDevicesViewModel : ObservableObject
    {
        List<DisplayableDevice> _devices;

        public List<DisplayableDevice> Devices
        {
            get { return _devices; }
            set
            {
                _devices = value;
                OnPropertyChanged();
            }
        }

        public AvailableDevicesViewModel()
        {
            _devices = new();
        }
    }
}
