import CreateNewsRoute from './create';
import NewsDetailRoute from './detail';
import UpdateNewsRoute from './update';

const NewsRoute = {
  children: [
    {
      index: true,
      lazy: async () => {
        const { NewsTablePage: NewsTablePage } = await import('./table/news-table-page');
        return { Component: NewsTablePage };
      }
    },
    CreateNewsRoute,
    NewsDetailRoute,
    UpdateNewsRoute
  ]
};

export default NewsRoute;
