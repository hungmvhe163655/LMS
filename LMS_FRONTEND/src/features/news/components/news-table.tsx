import * as React from 'react';

import { useNews } from '../api/get-news';

import { getColumns } from './news-columns';

import { DataTable } from '@/components/ui/data-table/data-table';
import { useDataTable } from '@/hooks/use-data-table';

export function NewsTable() {
  const [paginationParameter, setPaginationParameter] = React.useState({
    PageNumber: 1,
    PageSize: 10
  });

  const { data } = useNews({ paginationParameter });

  // Memoize the columns so they don't re-render on every render
  const columns = React.useMemo(() => getColumns(), []);

  const { table } = useDataTable({
    data: data?.data || [],
    pageCount: data?.pagination.TotalPages || 1,
    columns
  });

  const pageIndex = table.getState().pagination.pageIndex + 1;
  const pageSize = table.getState().pagination.pageSize;

  React.useEffect(() => {
    setPaginationParameter({
      PageNumber: pageIndex,
      PageSize: pageSize
    });
  }, [pageIndex, pageSize]);

  return <DataTable table={table} />;
}
