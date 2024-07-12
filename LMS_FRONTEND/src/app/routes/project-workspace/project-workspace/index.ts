const ProjectWorkspaceRoute = {
  path: 'project-workspace',
  lazy: async () => {
    const { ProjectWorkspacePage: ProjectWorkspacePage } = await import('./project-workspace-page');
    return { Component: ProjectWorkspacePage };
  }
};

export default ProjectWorkspaceRoute;
