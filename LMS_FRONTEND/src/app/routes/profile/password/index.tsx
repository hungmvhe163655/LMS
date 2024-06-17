const PasswordRoute = {
  path: 'phone-number',
  lazy: async () => {
    const { Password } = await import('./password');
    return { Component: Password };
  }
};

export default PasswordRoute;
