using ath_p4_proj2.Database;
using ath_p4_proj2.Models;
using ath_p4_proj2.ViewModels;
using System.Linq;
using System.Windows;


namespace ath_p4_proj2.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AvailableDevicesWindow.xaml
    /// </summary>
    public partial class AvailableDevicesWindow : Window
    {
        public AvailableDevicesWindow()
        {
            InitializeComponent();
            var ctx = DataContext as AvailableDevicesViewModel;
            var devices = HelperFunctions.GetAvailableDevices();
            ctx.Devices = devices.ConvertAll(x => new DisplayableDevice(x)).ToList();
        }
    }
}
