const ResourcesRoute = {
  path: ':projectId/resources/:folderId',
  lazy: async () => {
    const { ProjectResourcesTablePage: ProjectResourcesTablePage } = await import(
      './project-resources-table'
    );
    return { Component: ProjectResourcesTablePage };
  }
};

export default ResourcesRoute;
