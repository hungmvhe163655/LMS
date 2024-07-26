import { useMemo } from 'react';
import { useSearchParams } from 'react-router-dom';

import { DataTable } from '@/components/ui/data-table/data-table';
import { DataTableSkeleton } from '@/components/ui/data-table/data-table-skeleton';
import { useDataTable } from '@/hooks/use-data-table';

import { useNews } from '../api/get-news';

import { getColumns } from './news-columns';
import { NewsTableToolbarActions } from './news-table-toolbar-actions';

export function NewsTable() {
  const [searchParams] = useSearchParams();

  const page = searchParams.get('page') || 1;
  const perPage = searchParams.get('per_page') || 10;
  const sort = searchParams.get('sort');
  const searchTerm = searchParams.get('search_term');

  const { data, isLoading } = useNews({
    newsQueryParameter: {
      PageNumber: Number(page),
      PageSize: Number(perPage),
      OrderBy: sort,
      SearchTerm: searchTerm
    }
  });

  // Memoize the columns so they don't re-render on every render
  const columns = useMemo(() => getColumns(), []);

  const { table } = useDataTable({
    data: data?.data || [],
    pageCount: data?.pagination.TotalPages || 0,
    columns
  });

  if (isLoading) {
    return <DataTableSkeleton columnCount={3} rowCount={8} shrinkZero={true} />;
  }

  return (
    <DataTable table={table}>
      <NewsTableToolbarActions />
    </DataTable>
  );
}
