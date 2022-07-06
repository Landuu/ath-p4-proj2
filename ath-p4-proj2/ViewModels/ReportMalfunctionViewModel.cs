using ath_p4_proj2.Commands;
using ath_p4_proj2.Models;
using ath_p4_proj2.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ath_p4_proj2.ViewModels
{
    internal class ReportMalfunctionViewModel : ObservableObject, IDataErrorInfo
    {
        public ReportMalfunctionWindow window;

        private int _employeeId;
        public int EmployeeId
        {
            get { return _employeeId; }
            set
            {
                _employeeId = value;
                OnPropertyChanged();
            }
        }

        private List<DisplayableDevice> _devices;
        public List<DisplayableDevice> Devices
        {
            get { return _devices; }
            set
            {
                _devices = value;
                OnPropertyChanged();
            }
        }

        private DisplayableDevice _selectedDevice;
        public DisplayableDevice SelectedDevice
        {
            get { return _selectedDevice; }
            set
            {
                _selectedDevice = value;
                OnPropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public SendReportCommand SendReportCommand { get; set; }


        private EContainer _errorContainer = new();
        public string Error
        {
            get { return _errorContainer.ToString(); }
            set { OnPropertyChanged(); }
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "SelectedDevice":
                        _errorContainer -= EContainer.EIndex.DeviceNull;
                        if (SelectedDevice is null)
                            _errorContainer += EContainer.EIndex.DeviceNull;
                        break;
                    case "Description":
                        _errorContainer -= EContainer.EIndex.DescriptionEmpty;
                        _errorContainer -= EContainer.EIndex.DescriptionTooShort;

                        if (string.IsNullOrEmpty(Description))
                            _errorContainer += EContainer.EIndex.DescriptionEmpty;
                        if (Description is not null && Description.Length < 10)
                            _errorContainer += EContainer.EIndex.DescriptionTooShort;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Nieznane pole: " + columnName);
                }
                Error = "Głupie no nie? XDDDD";
                return Error;
            }
        }

        public ReportMalfunctionViewModel()
        {
            SendReportCommand = new(this);
        }

        class EContainer
        {
            public enum EIndex { DeviceNull, DescriptionEmpty, DescriptionTooShort }

            private static readonly Dictionary<EIndex, string> Messages = new()
            {
                { EIndex.DeviceNull, "Pole urządzenie nie może być puste!" },
                { EIndex.DescriptionEmpty, "Pole opis usterki nie może być puste!" },
                { EIndex.DescriptionTooShort, "Pole opis usterki musi zawierać conajmniej 10 znaków!" }
            };

            private bool[] Errors;

            public EContainer()
            {
                Errors = new bool[Messages.Count];
            }

            public static EContainer operator +(EContainer container, EIndex error)
            {
                container.Errors[(int)error] = true;
                return container;
            }

            public static EContainer operator -(EContainer container, EIndex error)
            {
                container.Errors[(int)error] = false;
                return container;
            }

            public override string ToString()
            {
                var s = string.Empty;
                for (int i = 0; i < Errors.Length; i++)
                {
                    if (!Errors[i]) continue;
                    s += Messages[(EIndex)i] + ", \n";

                }
                return s;
            }
        }
    }
}
