using ath_p4_proj2.Database;
using ath_p4_proj2.ViewModels;
using System.Windows;

namespace ath_p4_proj2.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy MyReportedMalfunctions.xaml
    /// </summary>
    public partial class MyReportedDeviceMalfunctionsWindow : Window
    {
        public MyReportedDeviceMalfunctionsWindow(int employeeId)
        {
            InitializeComponent();
            var ctx = DataContext as MyReportedDeviceMalfunctionsViewModel;
            var devices = HelperFunctions.GetOwnedDevices(employeeId);
            ctx.Malfunctions = HelperFunctions.GetDeviceMalfunctionsForDevices(devices);
        }
    }
}
