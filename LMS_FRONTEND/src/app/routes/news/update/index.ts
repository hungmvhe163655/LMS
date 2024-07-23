const UpdateNewsRoute = {
  path: 'update/:id',
  lazy: async () => {
    const { UpdateNewsPage: UpdateNewsPage } = await import('./update-page');
    return { Component: UpdateNewsPage };
  }
};

export default UpdateNewsRoute;
