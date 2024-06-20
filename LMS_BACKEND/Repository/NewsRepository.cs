using Contracts.Interfaces;
using Entities.Models;

namespace Repository
{
    public class NewsRepository : RepositoryBase<News>, INewsRepository
    {
        public NewsRepository(DataContext context) : base(context)
        {
            //implement logic crud news vao day
        }
    }
}
