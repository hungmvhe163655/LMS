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
            return GetByCondition(x => x.TaskId.Equals(taskId) && x.ParentId == null, false).Include(x => x.Childs).ThenInclude(y => y.CreatedByUser).Include(z => z.CreatedByUser);
        }

        public async Task<List<Comment>> GetCommentByTaskId2(Guid taskId)
        {
            var comments = GetByCondition(x => x.TaskId.Equals(taskId) && x.ParentId == null, true)
                            .Include(x => x.CreatedByUser)
                            .Include(x => x.Childs)
                            .ToList();

            foreach (var comment in comments) await LoadChildren(comment);
            
            return comments;
        }

        private async Task LoadChildren(Comment comment)
        {
            if (comment.Childs == null || comment.Childs.Count == 0)
            {
                return;
            }

            // Load children and their CreatedByUser property
            foreach (var child in comment.Childs)
            {
                await _context.Entry(child).Collection(c => c.Childs).LoadAsync();
                await _context.Entry(child).Reference(c => c.CreatedByUser).LoadAsync();

                // Recursively load grandchildren
                await LoadChildren(child);
            }
        }

        public async Task CreateComment(Comment comment)
        {
            await CreateAsync(comment);
        }

        public IQueryable<Comment> GetCommentById(Guid Id, bool track)
        {
            return GetByCondition(x => x.Id.Equals(Id), track).Include(x => x.Childs).Include(x => x.CreatedByUser);
        }

        public void UpdateComment(Comment comment)
        {
            Update(comment);
        }
    }
}
