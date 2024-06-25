using Contracts.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class StudentDetailRepository : RepositoryBase<StudentDetail>, IStudentDetailRepository
    {
        public StudentDetailRepository(DataContext context) : base(context)
        {
        }



    }
}
