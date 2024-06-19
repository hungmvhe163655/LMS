const PasswordRoute = {
  path: 'password',
  lazy: async () => {
    const { Password } = await import('./password');
    return { Component: Password };
  }
};

export default PasswordRoute;
