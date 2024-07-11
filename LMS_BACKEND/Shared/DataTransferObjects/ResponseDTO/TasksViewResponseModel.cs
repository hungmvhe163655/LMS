namespace Shared.DataTransferObjects.ResponseDTO
{
    public class TasksViewResponseModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string AssignedTo { get; set; } = null!;
        public string AssignedToUser { get; set; } = null!;
        public string TaskStatus { get; set; } = null!;
    }
}
