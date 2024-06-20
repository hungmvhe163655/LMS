const StudentDashboardRoute = {
  path: 'student',
  lazy: async () => {
    const { StudentDashboardPage: StudentDashboardPage } = await import('./dashboard-page');
    return { Component: StudentDashboardPage };
  }
};

export default StudentDashboardRoute;
