using ath_p4_proj2.ViewModels;
using ath_p4_proj2.Windows;
using System;
using System.Windows;
using System.Windows.Input;

namespace ath_p4_proj2.Commands
{
    internal class OpenWindowCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly MainViewModel _context;

        public OpenWindowCommand(MainViewModel context)
        {
            _context = context;
        }

        public bool CanExecute(object? parameter)
        {
            string? param = parameter as string;
            return param is not null;
        }

        public void Execute(object? parameter)
        {
            Window? window = null;
            string? param = parameter as string;

            switch (param)
            {
                case "MyDevices":
                    window = new MyDevicesWindow(_context.User.EmployeeId);
                    break;
                case "AvailableDevices":
                    window = new AvailableDevicesWindow();
                    break;
                case "ReportMalfunction":
                    window = new ReportMalfunctionWindow(_context.User.EmployeeId);
                    break;
                case "MyReportedDeviceMalfunctions":
                    window = new MyReportedDeviceMalfunctionsWindow(_context.User.EmployeeId);
                    break;
                default:
                    break;
            }

            if (window is null) return;
            window.ShowDialog();
        }
    }
}
