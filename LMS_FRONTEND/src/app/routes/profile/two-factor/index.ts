const TwoFactorRoute = {
  path: 'two-factor',
  lazy: async () => {
    const { TwoFactor } = await import('./two-factor');
    return { Component: TwoFactor };
  }
};

export default TwoFactorRoute;
