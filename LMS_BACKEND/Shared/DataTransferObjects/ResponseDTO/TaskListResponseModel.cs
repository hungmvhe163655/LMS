using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class TaskListResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<TasksViewResponseModel>? Tasks { get; set; }
    }
}
