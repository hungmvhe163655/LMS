import CreateNewsRoute from './create';

const ListNewsRoute = {
  path: 'list',
  lazy: async () => {
    const { ListNewsPage: ListNewsPage } = await import('./list-page');
    return { Component: ListNewsPage };
  },
  children: [CreateNewsRoute]
};

export default ListNewsRoute;
