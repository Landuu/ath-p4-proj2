using ath_p4_proj2.Windows;
using System;
using System.Windows.Input;

namespace ath_p4_proj2.Commands
{
    internal class OpenWindowCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var window = new AvailableDevicesWindow();
            window.ShowDialog();
        }
    }
}
