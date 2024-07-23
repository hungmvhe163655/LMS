import { ColumnDef } from '@tanstack/react-table';

import { Link } from '@/components/app/link';
import { DataTableColumnHeader } from '@/components/ui/data-table/data-table-column-header';
import { formatDate } from '@/utils/format';

import { News } from '../types/api';

export function getColumns(): ColumnDef<News>[] {
  return [
    {
      accessorKey: 'title',
      header: ({ column }) => <DataTableColumnHeader column={column} title='Title' />,
      cell: ({ row }) => <Link to={`/news/${row.original.id}`}>{row.original.title}</Link>,
      enableSorting: false,
      enableHiding: false
    },
    {
      accessorKey: 'createdBy',
      header: ({ column }) => <DataTableColumnHeader column={column} title='Created By' />,
      enableHiding: false,
      enableSorting: false
    },
    {
      accessorKey: 'createdDate',
      header: ({ column }) => <DataTableColumnHeader column={column} title='Created Date' />,
      cell: ({ cell }) => formatDate(cell.getValue() as Date),
      enableHiding: false
    },
    {
      id: 'edit',
      cell: ({ row }) => (
        <Link variant='button' to={`/news/update/${row.original.id}`}>
          Update
        </Link>
      ),
      enableHiding: false
    }
  ];
}
