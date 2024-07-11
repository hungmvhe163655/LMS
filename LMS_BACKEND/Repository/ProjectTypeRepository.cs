using Contracts.Interfaces;
using Entities.Models;

namespace Repository
{
    public class ProjectTypeRepository : RepositoryBase<ProjectType>, IProjectTypeRepository
    {
        public ProjectTypeRepository(DataContext context) : base(context)
        {
        }
    }
}
