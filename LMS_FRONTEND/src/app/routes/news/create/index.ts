const CreateNewsRoute = {
  path: 'create',
  lazy: async () => {
    const { CreateNewsPage: CreateNewsPage } = await import('./create-page');
    return { Component: CreateNewsPage };
  }
};

export default CreateNewsRoute;
