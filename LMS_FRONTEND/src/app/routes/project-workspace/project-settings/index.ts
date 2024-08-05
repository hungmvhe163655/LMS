const ProjectSettingsRoute = {
  path: 'settings',
  lazy: async () => {
    const { ProjectSettingsPage: ProjectSettingsPage } = await import('./project-settings-page');
    return { Component: ProjectSettingsPage };
  }
};

export default ProjectSettingsRoute;
