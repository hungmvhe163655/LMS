﻿namespace Shared.DataTransferObjects.RequestDTO
{
    public class NewsRequestCreateModel
    {
        public string CreatedBy { get; set; }
        public string Content { get; set; }
        public string Title { get; set; } = null!;

        public int? AccountCreatedId { get; set; }

        List<string> FileKeys { get; set; }
    }

    public class NewsRequestUpdateModel
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string Content { get; set; }
        public string Title { get; set; } = null!;

        public int? AccountCreatedId { get; set; }

        List<string> FileKeys { get; set; }
    }

    public class NewsRequestGetListsModel
    {
        public string? title { get; set; }
        public int pageIndex { get; set; } = 0;
        public int pageSize { get; set; } = 5;
    }
}
