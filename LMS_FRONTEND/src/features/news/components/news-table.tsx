import { useNewsTable } from '../hooks/use-news-table';

import { DataTable } from '@/components/ui/data-table/data-table';
import { DataTableSkeleton } from '@/components/ui/data-table/data-table-skeleton';

export function NewsTable() {
  const { isLoading, error, table } = useNewsTable();

  if (error) {
    return <div>Error: {error.message}</div>;
  }

  if (isLoading) {
    return <DataTableSkeleton columnCount={3} />;
  }

  return <DataTable table={table} />;
}
