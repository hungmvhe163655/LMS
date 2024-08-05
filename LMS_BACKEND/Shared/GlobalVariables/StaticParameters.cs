using Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.GlobalVariables
{
    public class MAPPARAM
    {
        public static string GetTaskPriorityValue(string key)
        {
            return GetValue(_taskPriorityMappings, key);
        }

        public static string GetTaskStatusValue(string key)
        {
            return GetValue(_taskStatusMappings, key);
        }

        public static string GetDeviceStatusValue(string key)
        {
            return GetValue(_deviceStatusMappings, key);
        }

        public static string GetNotificationTypeValue(string key)
        {
            return GetValue(_notificationTypeMappings, key);
        }

        public static string GetProjectTypeValue(string key)
        {
            return GetValue(_projectTypeMappings, key);
        }

        public static string GetProjectStatusValue(string key)
        {
            return GetValue(_projectStatusMappings, key);
        }

        private static string GetValue(IDictionary<string, string> mappings, string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            mappings.TryGetValue(key, out string? value);

            return value!=null ? value : throw new BadRequestException("Invalid string");
        }
        private static IDictionary<string, string> _taskPriorityMappings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            { TASK_PRIORITY.LOW, "Low" },
            { TASK_PRIORITY.MEDIUM, "Medium" },
            { TASK_PRIORITY.HIGH, "High" },
            { TASK_PRIORITY.CRITICAL, "Critical" }
        };

        private static IDictionary<string, string> _taskStatusMappings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            { TASK_STATUS.OPEN_TODO, "Open/To do" },
            { TASK_STATUS.DOING, "Doing" },
            { TASK_STATUS.REVIEW, "Review" },
            { TASK_STATUS.CLOSE, "Close" }
        };

        private static IDictionary<string, string> _deviceStatusMappings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            { DEVICE_STATUS.AVAILABLE, "Available" },
            { DEVICE_STATUS.INUSE, "In Use" },
            { DEVICE_STATUS.DISABLE, "Disable" }
        };

        private static IDictionary<string, string> _notificationTypeMappings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            { NOTIFICATION_TYPE.SYSTEM, "System" },
            { NOTIFICATION_TYPE.PROJECT, "Project" }
        };

        private static IDictionary<string, string> _projectTypeMappings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            { PROJECT_TYPE.WEBAPP, "Web Application" },
            { PROJECT_TYPE.RESEARCHPAPER, "Research Paper" },
            { PROJECT_TYPE.IOT, "Iot" },
            { PROJECT_TYPE.MOBILE, "Mobile app" },
            { PROJECT_TYPE.AI, "Ai" },
            { PROJECT_TYPE.VR, "Vr" }
        };

        private static IDictionary<string, string> _projectStatusMappings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            { PROJECT_STATUS.INITIALIZING, "Initializing" },
            { PROJECT_STATUS.ONGOING, "On-going" },
            { PROJECT_STATUS.COMPLETED, "Completed" },
            { PROJECT_STATUS.CANCEL, "Cancel" }
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

    public static class CACHE_PROFILE
    {
        public const string TWOMINUTES = "120SecondsDuration";
    }

    public static class REDIS_CACHE
    {
        public const string PROJECT_TASKS = "GetTasksWithProjectId";
    }

    public static class IMAGE_TYPE
    {
        public const string DEVICE = "Device";

        public const string REPORT = "Report";
    }

    public static class SCROLL_LIST
    {
        public const int TINY10 = 10;

        public const int SMALL30 = 30;

        public const int MEDIUM50 = 50;

        public const int LARGE100 = 100;

        public const int DEFAULT_TOP = 0;
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
