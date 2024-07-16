using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class MAPPARAM
    {
        public static int GetValue(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("extension");
            }

            int end;

            return _mappings.TryGetValue(key, out end) ? end : 0;
        }
        private static IDictionary<string, int> _mappings = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase)
        {
            {"LOW", 1 },
            {"MEDIUM",2 },
            {"HIGH",3 },
            {"CRITICAL",4 },

            {"Open/To do",1 },
            {"Doing",2 },
            {"Review",3 },
            {"Close",4 },

            {"AVAILABLE",1 },
            {"INUSE",2 },
            {"Disable",3 },

            {"SYSTEM", 1 },
            {"PROJECT",2 },

            {"WEBAPPLICATION",1 },
            {"RESEARCHPAPER",2 },
            {"IOT",3 },
            {"MOBILEAPP",4 },
            {"AI",5 },
            {"VR",6 },

            {"Initializing",1 },
            {"On-going",2 },
            {"Completed",3 },
            {"Cancel",4 }
        };
    }
    public static class StaticParameters
    {
        #region ROLES

        public const string ADMIN = "Labadmin";

        public const string SUPERVISOR = "Supervisor";

        public const string STUDENT = "Student";

        #endregion

        #region TASKPRIORITY

        public const int LOW = 1;

        public const int MEDIUM = 2;

        public const int HIGH = 3;

        public const int CRITICAL = 4;

        #endregion//n device status notification type project types project status task

        #region TASKSTATUS

        public const string OPEN_TODO = "Open/To do";

        public const string DOING = "Doing";

        public const string REVIEW = "Review";

        public const string CLOSE = "Close";

        #endregion

        #region 

        #endregion
    }
}
