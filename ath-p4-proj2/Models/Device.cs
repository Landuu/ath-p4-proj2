﻿
using System;
using System.Collections.Generic;

namespace ath_p4_proj2.Models
{
    public class Device
    {
        public int DeviceId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string? SerialNumber { get; set; }
        public DateTime? DateOfService { get; set; }
        public DateTime? DateOfEOL { get; set; }

        public List<DeviceHistory> History { get; set; }

        public bool IsOnePopulatedWithoutId =>
            !string.IsNullOrEmpty(Manufacturer)
            || !string.IsNullOrEmpty(Model)
            || !string.IsNullOrEmpty(SerialNumber)
            || DateOfService is not null;
        public bool IsPopulatedWithoutId =>
            !string.IsNullOrEmpty(Manufacturer)
            && !string.IsNullOrEmpty(Model)
            && !string.IsNullOrEmpty(SerialNumber)
            && DateOfService is not null;
        public bool IsOnePopulated =>
            IsOnePopulatedWithoutId
            || DeviceId != 0;
        public bool IsPopulated => 
            IsPopulatedWithoutId
            && DeviceId != 0;
        public bool IsOnePopulatedSearch =>
            DeviceId != 0
            || !string.IsNullOrEmpty(Manufacturer)
            || !string.IsNullOrEmpty(Model)
            || !string.IsNullOrEmpty(SerialNumber);

        public Device() {
            History = new List<DeviceHistory>();
        }

        public Device(string manufacturer, string model, string serialNumber, DateTime dateOfService)
        {
            History = new List<DeviceHistory>();
            Manufacturer = manufacturer;
            Model = model;
            SerialNumber = serialNumber;
            DateOfService = dateOfService;
        }

        public void Clear()
        {
            DeviceId = 0;
            Manufacturer = "";
            Model = "";
            SerialNumber = null;
            DateOfService = null;
            DateOfEOL = null;
        }
    }
}
