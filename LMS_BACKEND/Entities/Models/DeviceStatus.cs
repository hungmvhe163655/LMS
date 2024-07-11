﻿namespace Entities.Models
{
    public class DeviceStatus
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
    }
}
