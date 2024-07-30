const BannedAccountRoute = {
  path: 'ban-account',
  lazy: async () => {
    const { BannedPage: BannedPage } = await import('./ban-account-page');
    return { Component: BannedPage };
  }
};

export default BannedAccountRoute;
