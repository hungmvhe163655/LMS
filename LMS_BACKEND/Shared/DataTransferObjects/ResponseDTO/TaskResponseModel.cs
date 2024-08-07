﻿namespace Shared.DataTransferObjects.ResponseDTO
{
    public class TaskResponseModel
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? CreatedBy { get; set; }
        public bool? RequiredValidation { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string TaskPriority { get; set; } = "";
        public Guid TaskListId { get; set; }
        public Guid ProjectId { get; set; }
        public string TaskStatus { get; set; } = "";
        public string? AssignedTo { get; set; }
        public int Order { get; set; }
    }
}
