const BannedAccountRoute = {
  path: 'ban-account',
  lazy: async () => {
    const { NotVerifiedPage: NotVerifiedPage } = await import('./ban-account-page');
    return { Component: NotVerifiedPage };
  }
};

export default BannedAccountRoute;
