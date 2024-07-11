using Contracts.Interfaces;
using Entities.Models;

namespace Repository
{
    public class StudentDetailRepository : RepositoryBase<StudentDetail>, IStudentDetailRepository
    {
        public StudentDetailRepository(DataContext context) : base(context)
        {
        }



    }
}
