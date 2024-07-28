import { ColumnDef } from '@tanstack/react-table';

import { Checkbox } from '@/components/ui/checkbox';
import { DataTableColumnHeader } from '@/components/ui/data-table/data-table-column-header';

import { NeedVerfiedAccount } from '../types/api';

import { ConfirmValidationDialog } from './confirm-diaglog';

export function getColumns(): ColumnDef<NeedVerfiedAccount>[] {
  return [
    {
      id: 'select',
      header: ({ table }) => (
        <Checkbox
          checked={
            table.getIsAllPageRowsSelected() ||
            (table.getIsSomePageRowsSelected() && 'indeterminate')
          }
          onCheckedChange={(value) => table.toggleAllPageRowsSelected(!!value)}
          aria-label='Select all'
          className='translate-y-0.5'
        />
      ),
      cell: ({ row }) => (
        <Checkbox
          checked={row.getIsSelected()}
          onCheckedChange={(value) => row.toggleSelected(!!value)}
          aria-label='Select row'
          className='translate-y-0.5'
        />
      ),
      enableSorting: false,
      enableHiding: false
    },
    {
      accessorKey: 'fullName',
      header: ({ column }) => <DataTableColumnHeader column={column} title='Full Name' />,
      enableHiding: false
    },
    {
      id: 'action',
      cell: ({ row }) => (
        <div className='flex space-x-4'>
          <ConfirmValidationDialog
            userId={[row.original.id]}
            isAccept={true}
            onSuccess={() => row.toggleSelected(false)}
          />
          <ConfirmValidationDialog
            userId={[row.original.id]}
            isAccept={false}
            onSuccess={() => row.toggleSelected(false)}
          />
        </div>
      ),
      enableHiding: false,
      enableSorting: false
    }
  ];
}
