import { useMemo } from 'react';
import { useSearchParams } from 'react-router-dom';

import { DataTable } from '@/components/ui/data-table/data-table';
import { DataTableSkeleton } from '@/components/ui/data-table/data-table-skeleton';
import { useDataTable } from '@/hooks/use-data-table';

import { useGetVerifyAccounts } from '../api/get-verify-account';

import { getColumns } from './need-verified-columns';
import { VerfyAccountTableToolbarActions } from './verify-accounts-table-toolbar-actions';

export function VerifyAccountsTable() {
  const [searchParams] = useSearchParams();

  const page = searchParams.get('page') || 1;
  const perPage = searchParams.get('per_page') || 10;
  const searchContent = searchParams.get('search_content');

  const { data, isLoading } = useGetVerifyAccounts({
    verifiedAccountsQueryParameter: {
      PageNumber: Number(page),
      PageSize: Number(perPage),
      SearchContent: searchContent
    }
  });

  // Memoize the columns so they don't re-render on every render
  const columns = useMemo(() => getColumns(), []);

  const { table } = useDataTable({
    data: data?.data || [],
    pageCount: data?.pagination.TotalPages || 0,
    enableRowSelection: true,
    columns
  });

  if (isLoading) {
    return <DataTableSkeleton columnCount={2} rowCount={8} shrinkZero={true} />;
  }

  return (
    <DataTable table={table}>
      <VerfyAccountTableToolbarActions table={table} />
    </DataTable>
  );
}
