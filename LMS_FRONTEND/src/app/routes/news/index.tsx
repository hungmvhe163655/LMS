import CreateNewsRoute from './create';
import NewsDetailRoute from './detail';
import UpdateNewsRoute from './update';

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
    NewsDetailRoute,
    UpdateNewsRoute
  ]
};

export default NewsRoute;
