namespace Shared.DataTransferObjects.RequestDTO
{
    public class UpdateTaskListRequestModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int MaxTasks { get; set; }
    }
}
