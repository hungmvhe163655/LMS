const NeedVerifiedRoute = {
  path: 'need-verified',
  lazy: async () => {
    const { NeedVerifiedPage: NeedVerifiedPage } = await import('./need-verified-page');
    return { Component: NeedVerifiedPage };
  }
};

export default NeedVerifiedRoute;
