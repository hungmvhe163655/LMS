const NotVerifiedRoute = {
  path: 'not-verified',
  lazy: async () => {
    const { NotVerifiedPage: NotVerifiedPage } = await import('./not-verified-page');
    return { Component: NotVerifiedPage };
  }
};

export default NotVerifiedRoute;
