﻿namespace Shared.DataTransferObjects.ResponseDTO
{
    public class ProjectResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int TaskUndone { get; set; }
        public IEnumerable<TasksViewResponseModel>? ListTaskUndone { get; set; }
    }
}
