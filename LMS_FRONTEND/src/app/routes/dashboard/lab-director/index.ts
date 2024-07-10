const LabDirectorDashboardRoute = {
  path: 'lab-director',
  lazy: async () => {
    const { LabDirectorDashboardPage: LabDirectorDashboardPage } = await import('./dashboard-page');
    return { Component: LabDirectorDashboardPage };
  }
};

export default LabDirectorDashboardRoute;
