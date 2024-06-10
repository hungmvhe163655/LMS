using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface ILoggerManager
    {
        void LogInformation(string messages);
        void LogWarning(string messages);
        void LogError(string messages);
        void LogDebuger(string messages);
    }
}
