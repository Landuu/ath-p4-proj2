using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ath_p4_proj2.Models
{
    internal class DeviceMalfunction
    {
        public int DeviceMalfunctionId { get; set; }
        public int DeviceId { get; set; }
        public Device Device { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? RepairedAt { get; set; }

        public DeviceMalfunction() { }

        public DeviceMalfunction(int deviceId, Device device, string description, DateTime createdAt, DateTime? repairedAt = null)
        {
            DeviceId = deviceId;
            Device = device;
            Description = description;
            CreatedAt = createdAt;
            RepairedAt = repairedAt;
        }
    }
}
