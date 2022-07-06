using ath_p4_proj2.Database;
using ath_p4_proj2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
