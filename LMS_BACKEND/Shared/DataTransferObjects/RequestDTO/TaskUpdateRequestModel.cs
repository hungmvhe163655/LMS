﻿namespace Shared.DataTransferObjects.RequestDTO
{
    public class TaskUpdateRequestModel
    {
        public string? Title { get; set; }
        public string? CreatedBy { get; set; }
        public bool? RequiredValidation { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string TaskPriority { get; set; } = "";
        public string TaskStatus { get; set; } = "";
        public string? AssignedTo { get; set; }
        public byte[] RowVersion { get; set; } = new byte[0];
    }
}
