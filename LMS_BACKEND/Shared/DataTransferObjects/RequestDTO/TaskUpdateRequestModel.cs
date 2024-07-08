﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class TaskUpdateRequestModel
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? CreatedBy { get; set; }
        public bool? RequiredValidation { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int TaskPriorityId { get; set; }
        public Guid TaskListId { get; set; }
        public Guid ProjectId { get; set; }
        public int TaskStatusId { get; set; }
        public string? AssignedTo { get; set; }
        public byte[] RowVersion { get; set; } = new byte[0];
    }
}