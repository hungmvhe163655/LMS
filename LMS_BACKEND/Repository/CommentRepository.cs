using Contracts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(DataContext context) : base(context)
        {
        }

        public IQueryable<Comment> GetCommentByTaskId(Guid taskId)
        {
            return GetByCondition(x => x.TaskId.Equals(taskId) && x.ParentId == null, false).Include(x => x.Childs).Include(z => z.CreatedByUser);
        }

        public async Task CreateComment(Comment comment)
        {
            await CreateAsync(comment);
        }
        
        public IQueryable<Comment> GetCommentById(Guid Id, bool track)
        {
            return GetByCondition(x=>x.Id.Equals(Id), track).Include(x => x.Childs).Include(x => x.CreatedByUser);
        }

        public void UpdateComment(Comment comment)
        {
            Update(comment);
        }
    }
}
