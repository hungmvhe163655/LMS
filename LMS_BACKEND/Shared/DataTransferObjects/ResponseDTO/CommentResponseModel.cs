using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class CommentResponseModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Content { get; set; }
        public Guid? ParentId { get; set; }
        public Guid TaskId { get; set; }
        public AccountReturnModel CreatedByUser { get; set; } = null!;
        public ICollection<CommentResponseModel> Childs { get; set; } = new List<CommentResponseModel>();
        public Tasks Task { get; set; } = null!;
    }
}
