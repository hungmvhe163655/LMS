using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.GlobalVariables
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
    public static class ROLES
    {
        public const string ADMIN = "Labadmin";

        public const string SUPERVISOR = "Supervisor";

        public const string STUDENT = "Student";
    }

    public static class TASK_PRIORITY
    {
        public const string LOW = "Low";

        public const string MEDIUM = "Medium";

        public const string HIGH = "High";

        public const string CRITICAL = "Critical";
    }

    public static class TASK_STATUS
    {
        public const string OPEN_TODO = "Open/To do";

        public const string DOING = "Doing";

        public const string REVIEW = "Review";

        public const string CLOSE = "Close";
    }
    
    public static class DEVICE_STATUS
    {
        public const string AVAILABLE = "Available";

        public const string INUSE = "In Use";

        public const string DISABLE = "Disable";
    }
    public static class NOTIFICATION_TYPE
    {
        public const string SYSTEM = "System";

        public const string PROJECT = "Project";
    }

    public static class PROJECT_TYPE
    {
        public const string WEBAPP = "Web Application";

        public const string RESEARCHPAPER = "Research Paper";

        public const string IOT = "Iot";

        public const string MOBILE = "Mobile app";

        public const string AI = "Ai";

        public const string VR = "Vr";
    }

    public static class PROJECT_STATUS
    {
        public const string INITIALIZING = "Initializing";

        public const string ONGOING = "On-going";

        public const string COMPLETED = "Completed";

        public const string CANCEL = "Cancel";
    }

    //public static class StaticParameters
    //{
    //    #region ROLES

    //    public const string ADMIN = "Labadmin";

    //    public const string SUPERVISOR = "Supervisor";

    //    public const string STUDENT = "Student";

    //    #endregion

    //    #region TASK PRIORITY

    //    public const string LOW = "Low";

    //    public const string MEDIUM = "Medium";

    //    public const string HIGH = "High";

    //    public const string CRITICAL = "Critical";

    //    #endregion//n device status notification type project types project status task

    //    #region TASK STATUS

    //    public const string OPEN_TODO = "Open/To do";

    //    public const string DOING = "Doing";

    //    public const string REVIEW = "Review";

    //    public const string CLOSE = "Close";

    //    #endregion

    //    #region DEVICE STATUS

    //    public const string AVAILABLE = "Available";

    //    public const string INUSE = "In Use";

    //    public const string DISABLE = "Disable";

    //    #endregion

    //    #region NOTIFICATION TYPES

    //    public const string SYSTEM = "System";

    //    public const string PROJECT = "Project";

    //    #endregion

    //    #region PROJECT TYPES

    //    public const string WEBAPP = "Web Application";

    //    public const string RESEARCHPAPER = "Research Paper";

    //    public const string IOT = "Iot";

    //    public const string MOBILE = "Mobile app";

    //    public const string AI = "Ai";

    //    public const string VR = "Vr";

    //    #endregion

    //    #region PROJECT STATUS

    //    public const string INITIALIZING = "Initializing";

    //    public const string ONGOING = "On-going";

    //    public const string COMPLETED = "Completed";

    //    public const string CANCEL = "Cancel";

    //    #endregion
    //}
}
