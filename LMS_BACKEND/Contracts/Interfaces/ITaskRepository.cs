using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface ITaskRepository
    {
        Task DeleteTask(Tasks task);
        Task UpdateTask(Tasks task);
        Task AddNewTask(Tasks task);
    }
}
