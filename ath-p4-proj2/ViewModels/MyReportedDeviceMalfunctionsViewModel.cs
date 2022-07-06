
using ath_p4_proj2.Models;
using System.Collections.Generic;

namespace ath_p4_proj2.ViewModels
{
    internal class MyReportedDeviceMalfunctionsViewModel : ObservableObject
    {
        private List<DeviceMalfunction> _malfunctions;

        public List<DeviceMalfunction> Malfunctions
        {
            get { return _malfunctions; }
            set
            {
                _malfunctions = value;
                OnPropertyChanged();
            }
        }

        public MyReportedDeviceMalfunctionsViewModel()
        {
            _malfunctions = new();
        }
    }
}
