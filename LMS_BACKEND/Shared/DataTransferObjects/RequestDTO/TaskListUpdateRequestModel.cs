﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class TaskListUpdateRequestModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int MaxTasks { get; set; }
        public Guid ProjectId { get; set; }
        public int Order { get; set; } = 0;

    }
}
