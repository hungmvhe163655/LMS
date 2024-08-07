const WorkspaceRoute = {
  path: 'workspace/:projectId',
  lazy: async () => {
    const { ProjectWorkspacePage: ProjectWorkspacePage } = await import('./project-workspace-page');
    return { Component: ProjectWorkspacePage };
  }
};

export default WorkspaceRoute;
