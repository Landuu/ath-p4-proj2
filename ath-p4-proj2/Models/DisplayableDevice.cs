using System;

namespace ath_p4_proj2.Models
{
    internal class DisplayableDevice
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public DateTime? DateOfService { get; set; }

        public DisplayableDevice(int id, string manufacturer, string model, DateTime dateOfService)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            DateOfService = dateOfService;
        }

        public DisplayableDevice(Device device)
        {
            Id = device.DeviceId;
            Manufacturer = device.Manufacturer;
            Model = device.Model;
            DateOfService = device.DateOfService;
        }
    }
}
