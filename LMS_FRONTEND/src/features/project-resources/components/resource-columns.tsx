import { ColumnDef } from '@tanstack/react-table';
import { defaultStyles, FileIcon } from 'react-file-icon';
import { FaFolder } from 'react-icons/fa';

import { DataTableColumnHeader } from '@/components/ui/data-table/data-table-column-header';
import { formatDateNoHours } from '@/utils/format';
import { humanFileSize } from '@/utils/format-file-size';
import { getFileExtension } from '@/utils/get-file-extension';

import { ResourceFile, ResourceFolder } from '../types/api';
import { RESOURCE } from '../types/constant';

import { DropdownActions } from './dropdown-actions';

export function getColumns(): ColumnDef<ResourceFolder | ResourceFile>[] {
  return [
    {
      accessorKey: 'name',
      header: ({ column }) => <DataTableColumnHeader column={column} title='Name' />,
      cell: ({ row }) => {
        const rowName = row.original.name;
        if (row.original.type === RESOURCE.FILE) {
          const ext = getFileExtension(row.original.name);
          return (
            <div className='flex items-center space-x-2'>
              <div className='flex size-6 items-center justify-center'>
                <FileIcon extension={ext} {...defaultStyles[ext as keyof typeof defaultStyles]} />
              </div>
              <span>{rowName}</span>
            </div>
          );
        }

        return (
          <div className='flex items-center space-x-2'>
            <FaFolder className='size-6' />
            <span>{rowName}</span>
          </div>
        );
      },
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
      cell: ({ cell }) => formatDateNoHours(cell.getValue() as Date),
      enableHiding: false
    },
    {
      accessorKey: 'size',
      header: ({ column }) => <DataTableColumnHeader column={column} title='Size' />,
      cell: ({ row }) => {
        return row.original.type === RESOURCE.FILE ? humanFileSize(row.original.size) : '-';
      },
      enableSorting: false,
      enableHiding: false
    },
    {
      id: 'actions',
      cell: ({ row }) => {
        return <DropdownActions row={row} />;
      },
      enableSorting: false,
      enableHiding: false
    }
  ];
}
