using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class DeviceReturnModel
    {
        public Guid Id { get; set; }
        public int DeviceStatusId { get; set; }
        public string? OwnedBy { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime LastUsed { get; set; }
        public bool IsDeleted { get; set; }
    }
}
