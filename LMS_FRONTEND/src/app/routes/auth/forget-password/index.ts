const ForgotPasswordRoute = {
  path: 'login',
  lazy: async () => {
    const { ForgotPasswordPage: ForgotPasswordPage } = await import('./forgot-password-page');
    return { Component: ForgotPasswordPage };
  }
};

export default ForgotPasswordRoute;
