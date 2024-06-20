const EmailRoute = {
  path: 'email',
  lazy: async () => {
    const { Email } = await import('./email');
    return { Component: Email };
  }
};

export default EmailRoute;
