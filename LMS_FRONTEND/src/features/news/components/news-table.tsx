import React from 'react';
import { useSearchParams } from 'react-router-dom';

import { DataTable } from '@/components/ui/data-table/data-table';
import { useDataTable } from '@/hooks/use-data-table';

import { useNews } from '../api/get-news';

import { getColumns } from './news-columns';

export function NewsTable() {
  const [searchParams] = useSearchParams();

  const page = searchParams.get('page') || 1;
  const perPage = searchParams.get('per_page') || 10;
  const sort = searchParams.get('sort');

  const { data } = useNews({
    newsQueryParameter: {
      PageNumber: Number(page),
      PageSize: Number(perPage),
      OrderBy: sort
    }
  });

  // Memoize the columns so they don't re-render on every render
  const columns = React.useMemo(() => getColumns(), []);

  const { table } = useDataTable({
    data: data?.data || [],
    pageCount: data?.pagination.TotalPages || -1,
    columns
  });

  return <DataTable table={table} />;
}
