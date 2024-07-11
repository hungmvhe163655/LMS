namespace Shared.DataTransferObjects.RequestDTO
{
    public class TaskCreateRequestModel
    {
        public string Title { get; set; } = null!;
        public string? CreatedBy { get; set; }
        public bool? RequiredValidation { get; set; }
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int TaskPriorityId { get; set; }
        public Guid TaskListId { get; set; }
        public Guid ProjectId { get; set; }
        public int TaskStatusId { get; set; }
        public string? AssignedTo { get; set; }
    }
}
