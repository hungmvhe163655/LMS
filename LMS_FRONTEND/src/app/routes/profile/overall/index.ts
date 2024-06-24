const OverallRoute = {
  path: 'overall',
  lazy: async () => {
    const { OverallPage: Overall } = await import('./overall-page');
    return { Component: Overall };
  }
};

export default OverallRoute;
