import CreateNewsRoute from './create';

const ListNewsRoute = {
  path: 'list',
  children: [
    {
      index: true,
      lazy: async () => {
        const { ListNewsPage: ListNewsPage } = await import('./list-page');
        return { Component: ListNewsPage };
      }
    },
    CreateNewsRoute
  ]
};

export default ListNewsRoute;
