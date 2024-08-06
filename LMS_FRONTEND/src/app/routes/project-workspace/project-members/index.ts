const ProjectMembersRoute = {
  path: 'members/:projectId',
  lazy: async () => {
    const { ProjectMembersPage: ProjectMembersPage } = await import('./project-members-page');
    return { Component: ProjectMembersPage };
  }
};

export default ProjectMembersRoute;
