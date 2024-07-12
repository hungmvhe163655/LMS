using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class CreateNotificationRequestModel
    {
        [Required(ErrorMessage = "Title is require")]
        public string Title { get; set; }
        public string Content { get; set; }
        public int Type { get; set; }
        public string CreateUserId { get; set; }
        public CreateNotificationRequestModel(string title, string content, int type, string createUserId)
        {
            Title = title;
            Content = content;
            Type = type;
            CreateUserId = createUserId;
        }
    }
}
