using Contracts.Interfaces;
using Entities.Models;

namespace Repository
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(DataContext context) : base(context)
        {
        }
    }
}
