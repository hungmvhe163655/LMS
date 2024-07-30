namespace Shared.DataTransferObjects.RequestDTO
{
    public class TaskCreateRequestModel
    {
        public string Title { get; set; } = null!;
        public bool? RequiredValidation { get; set; }
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string TaskPriority { get; set; } = "";
        public Guid TaskListId { get; set; }
        public Guid ProjectId { get; set; }
        public string TaskStatus { get; set; } = "";
        public string? AssignedTo { get; set; }
    }
}
