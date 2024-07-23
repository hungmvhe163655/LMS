import CreateNewsRoute from './create';
import NewsDetailRoute from './detail';

const NewsRoute = {
  children: [
    {
      index: true,
      lazy: async () => {
        const { ListNewsPage: ListNewsPage } = await import('./list/list-page');
        return { Component: ListNewsPage };
      }
    },
    CreateNewsRoute,
    NewsDetailRoute
  ]
};

export default NewsRoute;
