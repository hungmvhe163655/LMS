using Entities.Models;
using Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FileRepository : RepositoryBase<Files>, IFileRepository
    {
        public FileRepository(DataContext context) : base(context)
        {
        }

    }
}
