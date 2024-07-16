const OngoingProjectsRoute = {
  index: true,
  lazy: async () => {
    const { OngoingProjectsPage: OngoingProjectsPage } = await import('./ongoing-projects-page');
    return { Component: OngoingProjectsPage };
  }
};

export default OngoingProjectsRoute;
