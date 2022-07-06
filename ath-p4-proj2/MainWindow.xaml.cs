using ath_p4_proj2.Database;
using ath_p4_proj2.ViewModels;
using System.Linq;
using System.Windows;

namespace ath_p4_proj2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using var context = new InventoryDbContext();
            bool wasCreated = context.Database.EnsureCreated();
            if (wasCreated) SeedDb.Run();
            var ctx = DataContext as MainViewModel;
            ctx.User = context.Employees.Where(x => x.EmployeeId == 1).First();
        }
    }
}
