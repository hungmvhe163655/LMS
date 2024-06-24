const SupervisorRegisterRoute = {
  path: 'supervisor',
  lazy: async () => {
    const { SupervisorRegisterPage: SupervisorRegisterPage } = await import('./register-page');
    return { Component: SupervisorRegisterPage };
  }
};

export default SupervisorRegisterRoute;
