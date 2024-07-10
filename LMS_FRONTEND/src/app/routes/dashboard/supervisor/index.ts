const SupervisorDashboardRoute = {
  path: 'supervisor',
  lazy: async () => {
    const { SupervisorDashboardPage: SupervisorDashboardPage } = await import('./dashboard-page');
    return { Component: SupervisorDashboardPage };
  }
};

export default SupervisorDashboardRoute;
