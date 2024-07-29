const ProjectResourcesRoute = {
  children: [
    {
      index: true,
      lazy: async () => {
        const { ProjectResourcesTablePage: ProjectResourcesTablePage } = await import(
          './table/project-resources-table'
        );
        return { Component: ProjectResourcesTablePage };
      }
    }
  ]
};

export default ProjectResourcesRoute;
