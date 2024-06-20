const ValidateEmailRoute = {
  path: 'email',
  lazy: async () => {
    const { ValidateEmailPage: ValidateEmailPage } = await import('./validate-email-page');
    return { Component: ValidateEmailPage };
  }
};

export default ValidateEmailRoute;
