namespace Shared.DataTransferObjects.ResponseDTO
{
    public class TaskListResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Order { get; set; }
        public ICollection<TasksViewResponseModel>? Tasks { get; set; }
    }
}
