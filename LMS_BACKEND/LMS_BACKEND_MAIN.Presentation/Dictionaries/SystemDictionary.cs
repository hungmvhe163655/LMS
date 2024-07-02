namespace LMS_BACKEND_MAIN.Presentation.Dictionaries
{
    public static class APIs
    {
        public const string AuthenticationAPI = "api/auth";
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

    }
}
