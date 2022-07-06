

using ath_p4_proj2.Models;
using System.Collections.Generic;

namespace ath_p4_proj2.ViewModels
{
    internal class MyDevicesViewModel : ObservableObject
    {
        private List<DisplayableDevice> _devices;

        public List<DisplayableDevice> Devices {
            get { return _devices; }
            set { 
                _devices = value;
                OnPropertyChanged();
            }
        }

        public MyDevicesViewModel()
        {
            _devices = new();
        }
    }
}
