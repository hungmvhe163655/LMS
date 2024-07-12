const ListAllTasksRoute = {
  path: 'tasks',
  lazy: async () => {
    const { ListAllTasksPage: ListAllTasksPage } = await import('./list-all-tasks-page');
    return { Component: ListAllTasksPage };
  }
};

export default ListAllTasksRoute;
