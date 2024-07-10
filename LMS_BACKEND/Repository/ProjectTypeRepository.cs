using Contracts.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProjectTypeRepository : RepositoryBase<ProjectType>, IProjectTypeRepository
    {
        public ProjectTypeRepository(DataContext context) : base(context)
        {
        }
    }
}
