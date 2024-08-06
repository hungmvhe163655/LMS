const ProjectSettingsRoute = {
  path: 'settings/:projectId',
  lazy: async () => {
    const { ProjectSettingsPage: ProjectSettingsPage } = await import('./project-settings-page');
    return { Component: ProjectSettingsPage };
  }
};

export default ProjectSettingsRoute;
