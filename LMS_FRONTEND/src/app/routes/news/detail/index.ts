const NewsDetailRoute = {
  path: ':id',
  lazy: async () => {
    const { NewsDetailPage: NewsDetailPage } = await import('./detail-page');
    return { Component: NewsDetailPage };
  }
};

export default NewsDetailRoute;
