using Entities.Models;
using Shared.DataTransferObjects.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface ICommentRepository
    {
        IQueryable<Comment> GetCommentByTaskId(Guid taskId, CommentParameters param);
        Task<List<Comment>> GetCommentByTaskId2(Guid taskId, CommentParameters param);
        Task CreateComment(Comment comment);
        IQueryable<Comment> GetCommentById(Guid Id, bool track);
        void UpdateComment(Comment comment);
    }
}
