const ListProjectTasksRoute = {
  path: 'project-tasks',
  lazy: async () => {
    const { ListProjectTasksPage: ListProjectTasksPage } = await import(
      './list-project-tasks-page'
    );
    return { Component: ListProjectTasksPage };
  }
};

export default ListProjectTasksRoute;
