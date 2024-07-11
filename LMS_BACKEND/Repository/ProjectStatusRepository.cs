using Contracts.Interfaces;
using Entities.Models;

namespace Repository
{
    public class ProjectStatusRepository : RepositoryBase<ProjectStatus>, IProjectStatusRepository
    {
        public ProjectStatusRepository(DataContext context) : base(context)
        {
        }
    }
}
