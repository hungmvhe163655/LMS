namespace LMS_BACKEND_MAIN.Presentation.Dictionaries
{
    public static class APIs
    {
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

        public const string VerifyEmailSend = "verify-email-send";

        public const string GetCurrentLoggedInUser = "me";

        public const string ForgotPasswordOtp = "forgot-password-otp";

        public const string ForgotPassword = "forgot-password";

        public const string Logout = "logout";

        public const string Authenticate = "login";

        public const string Authenticate2Factor = "login-2factor";

        public const string RegisterStudent = "register/student";

        public const string RegisterSupervisor = "register/supervisor";

        public const string VerifyEmail = "verify-email";

        public const string ReSendVerifyEmail = "resend-verify-email";

        #endregion

        #region AccountAPIs

        public const string CreateAdmin = "create-admin";

        public const string GetAccountNeedVerified = "need-verified";

        public const string UpdateAccountVerifyStatus = "verify-account";

        #endregion

        #region FilesAPIs
        public const string UploadFile = "upload/{folderid:guid}";

        public const string DownloadFile = "download/{id:guid}";

        #endregion

        #region TokenAPIs

        public const string TokenRefresh = "refresh-token";

        #endregion

        #region ProfileAPIs

        public const string GetProjectWithMember = "{userId}/projects";

        public const string ChangePassword = "change-password";

        public const string ChangeEmailOtp = "change-email-otp/{id}";

        public const string ChangeEmail = "change-email/{id}";

        #endregion

        #region TaskAPIs

        public const string GetTaskByProjectId = "project/{id:guid}";

        #endregion

        #region ProjectAPIs

        public const string GetTaskListByProject = "{projectId:guid}/task-lists";

        public const string GetMemberInProject = "{projectId:guid}/members";

        #endregion
    }
}
