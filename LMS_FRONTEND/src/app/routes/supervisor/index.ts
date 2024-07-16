const SupervisorRoute = {
  children: [
    {
      index: true,
      lazy: async () => {
        const { DashboardPage: DashboardPage } = await import('./dashboard/dashboard');
        return { Component: DashboardPage };
      }
    }
  ]
};

export default SupervisorRoute;
