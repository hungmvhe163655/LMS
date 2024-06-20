const OverallRoute = {
  path: 'overall',
  lazy: async () => {
    const { Overall } = await import('./overall');
    return { Component: Overall };
  }
};

export default OverallRoute;
