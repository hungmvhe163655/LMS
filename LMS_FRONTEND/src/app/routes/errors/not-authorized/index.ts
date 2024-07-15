const NotAuthorizedRoute = {
  path: 'not-authorized',
  lazy: async () => {
    const { NotAuthorizedPage: NotAuthorizedPage } = await import('./not-authorized-page');
    return { Component: NotAuthorizedPage };
  }
};

export default NotAuthorizedRoute;
