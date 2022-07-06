using ath_p4_proj2.Database;
using ath_p4_proj2.Models;
using ath_p4_proj2.ViewModels;
using System;
using System.Windows.Input;

namespace ath_p4_proj2.Commands
{
    internal class SendReportCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly ReportMalfunctionViewModel _context;

        public SendReportCommand(ReportMalfunctionViewModel context)
        {
            _context = context;
        }

        public bool CanExecute(object? parameter)
        {
            /*            if (string.IsNullOrEmpty(_context.Description)) return false;
                        if (_context.DeviceId == 0) return false;
                        if (_context.EmployeeId == 0) return false;*/
            return true;
        }

        public void Execute(object? parameter)
        {
            if (_context.Error != string.Empty) return;
            var ctx = new InventoryDbContext();
            var malfunction = new DeviceMalfunction();
            malfunction.DeviceId = _context.SelectedDevice.Id;
            malfunction.Description = _context.Description;
            malfunction.CreatedAt = DateTime.Now;
            ctx.DeviceMalfunctions.Add(malfunction);
            ctx.SaveChanges();
            _context.window.Close();
        }
    }
}
