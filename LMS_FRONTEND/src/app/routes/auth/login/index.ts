const LoginRoute = {
  path: 'login',
  lazy: async () => {
    const { LoginPage: LoginPage } = await import('./login-page');
    return { Component: LoginPage };
  }
};

export default LoginRoute;
