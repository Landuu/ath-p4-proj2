using ath_p4_proj2.Database;
using ath_p4_proj2.Models;
using ath_p4_proj2.ViewModels;
using System.Linq;
using System.Windows;


namespace ath_p4_proj2.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy ReportMalfunctionWindow.xaml
    /// </summary>
    public partial class ReportMalfunctionWindow : Window
    {
        public ReportMalfunctionWindow(int employeeId)
        {
            InitializeComponent();
            var ctx = DataContext as ReportMalfunctionViewModel;
            ctx.EmployeeId = employeeId;
            ctx.window = this;
            ctx.Devices = HelperFunctions.GetOwnedDevices(employeeId).ConvertAll(x => new DisplayableDevice(x)).ToList();
        }
    }
}
