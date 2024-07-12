import CreateNewsRoute from './create';

const NewsRoute = {
  children: [
    {
      index: true,
      lazy: async () => {
        const { ListNewsPage: ListNewsPage } = await import('./list/list-page');
        return { Component: ListNewsPage };
      }
    },
    CreateNewsRoute
  ]
};

export default NewsRoute;
