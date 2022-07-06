
using ath_p4_proj2.Models;
using System.Collections.Generic;
using System.Linq;

namespace ath_p4_proj2.Database
{
    internal class HelperFunctions
    {
        public static bool GetDeviceAvaliability(int deviceId)
        {
            var ctx = new InventoryDbContext();
            bool isArchived = ctx.Devices.Where(x => x.DeviceId == deviceId).Where(x => x.DateOfEOL == null).FirstOrDefault() is null;
            if (isArchived) return false;

            bool hasHistory = ctx.DeviceHistories.Where(x => x.DeviceId == deviceId).FirstOrDefault() is not null;
            if (!hasHistory) return true;

            bool isAvailable = ctx.DeviceHistories.Where(x => x.DeviceId == deviceId).Where(x => x.DateOfReturn == null).FirstOrDefault() is null;
            return isAvailable;
        }

        public static List<Device> GetAvailableDevices()
        {
            var ctx = new InventoryDbContext();
            var devices = ctx.Devices.ToList();
            return devices.Where(x => GetDeviceAvaliability(x.DeviceId)).ToList();
        }

        public static List<Device> GetOwnedDevices(int employeeId)
        {
            var ctx = new InventoryDbContext();
            return ctx.DeviceHistories.Where(x => x.EmployeeId == employeeId).Where(x => x.DateOfReturn == null).Select(x => x.Device).ToList();
        }

        public static List<DeviceMalfunction> GetMalfunctionsForDevice(int deviceId)
        {
            var ctx = new InventoryDbContext();
            return ctx.DeviceMalfunctions.Where(x => x.DeviceId == deviceId).ToList();
        }

        public static List<DeviceMalfunction> GetDeviceMalfunctionsForDevices(List<Device> devices)
        {
            var ctx = new InventoryDbContext();
            var malfunctions = new List<DeviceMalfunction>();
            foreach (var device in devices)
            {
                malfunctions.AddRange(ctx.DeviceMalfunctions.Where(x => x.DeviceId == device.DeviceId));
            }
            return malfunctions;
        }
    }
}
