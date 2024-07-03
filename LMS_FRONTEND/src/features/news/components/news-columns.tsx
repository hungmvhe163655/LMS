import { ColumnDef } from '@tanstack/react-table';

import { DataTableColumnHeader } from '@/components/ui/data-table/data-table-column-header';
import { News } from '@/types/api';
import { formatDate } from '@/utils/format';

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
      accessorKey: 'createdAt',
      header: ({ column }) => <DataTableColumnHeader column={column} title='Created At' />,
      cell: ({ cell }) => formatDate(cell.getValue() as Date),
      enableHiding: false
    }
  ];
}
