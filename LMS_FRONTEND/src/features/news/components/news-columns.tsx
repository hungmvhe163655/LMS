import { ColumnDef } from '@tanstack/react-table';

import { DataTableColumnHeader } from '@/components/ui/data-table/data-table-column-header';
import { formatDate } from '@/utils/format';

import { News } from '../types/api';

export function getColumns(): ColumnDef<News>[] {
  return [
    {
      accessorKey: 'title',
      header: ({ column }) => <DataTableColumnHeader column={column} title='Title' />,
      enableSorting: false,
      enableHiding: false
    },
    {
      accessorKey: 'createdBy',
      header: ({ column }) => <DataTableColumnHeader column={column} title='Created By' />,
      enableSorting: false,
      enableHiding: false
    },
    {
      accessorKey: 'createdDate',
      header: ({ column }) => <DataTableColumnHeader column={column} title='Created Date' />,
      cell: ({ cell }) => formatDate(cell.getValue() as Date),
      enableHiding: false
    }
  ];
}
