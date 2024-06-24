const PasswordRoute = {
  path: 'password',
  lazy: async () => {
    const { PasswordPage: Password } = await import('./password-page');
    return { Component: Password };
  }
};

export default PasswordRoute;
