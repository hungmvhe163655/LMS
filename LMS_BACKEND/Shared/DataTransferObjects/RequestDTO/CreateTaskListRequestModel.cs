namespace Shared.DataTransferObjects.RequestDTO
{
    public class CreateTaskListRequestModel
    {
        public string Name { get; set; } = null!;
        public int MaxTasks { get; set; }
        public Guid ProjectId { get; set; }

    }
}
