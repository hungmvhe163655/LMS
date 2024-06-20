const EmailRoute = {
  path: 'email',
  lazy: async () => {
    const { EmailPage: Email } = await import('./email-page');
    return { Component: Email };
  }
};

export default EmailRoute;
