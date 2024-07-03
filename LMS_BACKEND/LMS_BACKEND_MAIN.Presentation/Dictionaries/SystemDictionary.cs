namespace LMS_BACKEND_MAIN.Presentation.Dictionaries
{
    public static class APIs
    {
        public const string AuthenticationAPI = "api/auth";

        public const string AccountAPI = "api/accounts";

        public const string FileAPI = "api/file";

        public const string FolderAPI = "api/folder";

        public const string NewsAPI = "api/news";

        public const string TOKEN = "api/token";
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

        public const string GetUsers = "accounts/{role}";

        public const string GetAccountNeedVerified = "need-verified";

        public const string UpdateAccountVerifyStatus = "verify-account";

        public const string ChangePassword = "change-password";

        #endregion

        #region FilesAPIs
        public const string UploadFile = "upload/{folderid:guid}";

        public const string DownloadFile = "download/{id:guid}";

        #endregion

        #region TokenAPIs

        public const string TokenRefresh = "refresh-token";

        #endregion

    }
}
