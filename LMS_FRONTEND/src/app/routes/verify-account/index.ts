const VerifyAccountsRoute = {
  children: [
    {
      index: true,
      lazy: async () => {
        const { VerifyTablePage: VerifyTablePage } = await import('./table/verify-table-page');
        return { Component: VerifyTablePage };
      }
    }
  ]
};

export default VerifyAccountsRoute;
