using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class CreateNotificationRequestModel
    {
        [Required(ErrorMessage = "Title is require")]
        public string Title { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public string CreateUserId { get; set; }
        public Guid? ProjectId { get; set; }
        public string? Group { get; set; } = "System";
        public CreateNotificationRequestModel(string title, string content, string type, string createUserId)
        {
            Title = title;
            Content = content;
            Type = type;
            CreateUserId = createUserId;
        }
    }
}
