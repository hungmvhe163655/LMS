import { ColumnDef } from '@tanstack/react-table';

import { DataTableColumnHeader } from '@/components/ui/data-table/data-table-column-header';

import { NeedVerfiedAccount } from '../types/api';

import { ConfirmValidationDialog } from './confirm-diaglog';

export function getColumns(): ColumnDef<NeedVerfiedAccount>[] {
  return [
    {
      accessorKey: 'fullName',
      header: ({ column }) => <DataTableColumnHeader column={column} title='Full Name' />,
      enableHiding: false
    },
    {
      id: 'action',
      cell: ({ row }) => (
        <div className='flex'>
          <ConfirmValidationDialog userId={row.original.id} isAccept={true} />
          <ConfirmValidationDialog userId={row.original.id} isAccept={false} />
        </div>
      ),
      enableHiding: false,
      enableSorting: false
    }
  ];
}
