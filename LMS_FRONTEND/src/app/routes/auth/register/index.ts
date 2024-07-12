const RegisterRoute = {
  path: 'register',
  lazy: async () => {
    const { RegisterPage: RegisterPage } = await import('./register-page');
    return { Component: RegisterPage };
  }
};

export default RegisterRoute;
