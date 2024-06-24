const TwoFactorRoute = {
  path: 'two-factor',
  lazy: async () => {
    const { TwoFactorPage: TwoFactorPage } = await import('./two-factor-page');
    return { Component: TwoFactorPage };
  }
};

export default TwoFactorRoute;
