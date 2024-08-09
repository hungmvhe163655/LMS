using Entities.Models;
using Repository.Extensions.Utility;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class CommentRepositoryExtentions
    {
        public static List<Comment> Sort(this List<Comment> list, string? orderBy)
        {
            if (string.IsNullOrEmpty(orderBy)) return list.OrderBy(n => n.CreatedDate).ToList();

            return list.OrderBy(x => x.CreatedDate).ToList();
        }
    }
}
