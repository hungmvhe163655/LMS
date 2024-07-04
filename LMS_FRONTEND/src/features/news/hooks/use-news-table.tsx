import * as React from 'react';

import { useNews } from '../api/get-news';
import { getColumns } from '../components/news-columns';

import { useDataTable } from '@/hooks/use-data-table';

export function useNewsTable() {
  const [newsQueryParameter, setNewsQueryParameter] = React.useState({
    PageNumber: 1,
    PageSize: 10
  });

  const { data, error, isLoading } = useNews({ newsQueryParameter: newsQueryParameter });

  // Memoize the columns so they don't re-render on every render
  const columns = React.useMemo(() => getColumns(), []);

  const { table } = useDataTable({
    data: data?.data || [],
    pageCount: data?.pagination.TotalPages || -1,
    columns
  });

  const { pageIndex, pageSize } = table.getState().pagination;

  React.useEffect(() => {
    setNewsQueryParameter({
      PageNumber: pageIndex + 1,
      PageSize: pageSize
    });
  }, [pageIndex, pageSize]);

  return { isLoading, error, table };
}
