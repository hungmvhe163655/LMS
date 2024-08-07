const DevicesListRoute = {
  index: true,
  lazy: async () => {
    const { DevicesListPage: DevicesListPage } = await import('./devices-list-page');
    return { Component: DevicesListPage };
  }
};

export default DevicesListRoute;
