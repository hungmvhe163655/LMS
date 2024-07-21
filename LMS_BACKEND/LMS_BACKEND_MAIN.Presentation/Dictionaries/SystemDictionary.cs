namespace LMS_BACKEND_MAIN.Presentation.Dictionaries
{
    public static class APIs
    {
        public const string DeviceAPI = "api/devices";

        public const string NotificationAPI = "api/notifications";

        public const string AuthenticationAPI = "api/auth";

        public const string AccountAPI = "api/accounts";

        public const string FileAPI = "api/files";

        public const string FolderAPI = "api/folders";

        public const string NewsAPI = "api/news";

        public const string TOKEN = "api/token";

        public const string ScheduleAPI = "api/schedules";

        public const string TaskAPI = "api/tasks";

        public const string ProjectAPI = "api/projects";

        public const string TaskListAPI = "api/task-lists";

        public const string ProfileAPI = "api/profile";

        public const string ReportAPI = "api/reports";
    }
    public static class AuthorizeScheme
    {
        public const string Bear = "Bearer";
    }
    public static class Roles
    {
        public const string ADMIN = "LabAdmin";

        public const string SUPERVISOR = "Supervisor";

        public const string ADMIN_SUPER = "LabAdmin, Supervisor";
    }
    public static class RoutesAPI
    {
        #region AuthenticationAPIs

        public const string ChangeVerifier = "verifier-change";

        public const string GetUsersSup = "accounts-supervisor";

        public const string VerifyEmailSend = "email-verification-send";

        public const string GetCurrentLoggedInUser = "me";

        public const string ForgotPasswordOtp = "forgot-password-otp";

        public const string ForgotPassword = "forgot-password";

        public const string Logout = "logout";

        public const string Authenticate = "login";

        public const string Authenticate2Factor = "login-2factor";

        public const string RegisterStudent = "register/student";

        public const string RegisterSupervisor = "register/supervisor";

        public const string VerifyEmail = "email-verification";

        public const string ReSendVerifyEmail = "email-verification-resend";

        #endregion

        #region AccountAPIs

        public const string CreateAdmin = "create-admin";

        public const string GetAccountNeedVerify = "verification";

        public const string GetSupervisorNeedVerify = "supervisor/verification";

        public const string UpdateAccountVerifyStatus = "verification";

        #endregion

        #region FilesAPIs

        public const string UploadFile = "upload/{folderid:guid}";

        public const string DownloadFile = "download/{id:guid}";

        public const string UploadImage = "upload/image";

        public const string DownloadImage = "download/image/{key}";

        public const string DeleteImage = "image/{key}";

        #endregion

        #region FolderAPIs

        public const string GetProjectFolderScheme = "/project/{id:guid}/root";

        #endregion

        #region TokenAPIs

        public const string TokenRefresh = "refresh-token";

        #endregion

        #region ProfileAPIs

        public const string GetProjectWithMember = "{userId}/projects";

        public const string ChangePassword = "change-password/{id}";

        public const string ChangePasswordOtp = "change-password-otp/{id}";

        public const string ChangeEmailOtp = "change-email-otp/{id}";

        public const string ChangeEmail = "change-email/{id}";

        #endregion

        #region TaskAPIs

        public const string GetTaskByProjectId = "project/{id:guid}";

        public const string AttachFileToTask = "add-file/{id:guid}/{fileid:guid}";

        #endregion

        #region TaskListAPIs

        public const string MoveTaskToTaskList = "{tasklistid:guid}/tasks/{taskid:guid}";

        #endregion

        #region ProjectAPIs

        public const string GetProjectResources = "{projectId:guid}/resources";

        public const string GetTaskListByProject = "{projectId:guid}/task-lists";

        public const string GetMemberInProject = "{projectId:guid}/members";

        public const string GetJoinRequest = "{id:guid}/join-request";

        public const string ValidateJoinRequest = "{id:guid}/join-request/validate";

        #endregion

        #region ReportsAPIs

        public const string GetAllByDeviceId = "device/{id:guid}";

        #endregion

        #region NotificationAPIs


        public const string MarkNotificationAsRead = "{id:guid}/read/user/{userid}";

        #endregion
    }
}
