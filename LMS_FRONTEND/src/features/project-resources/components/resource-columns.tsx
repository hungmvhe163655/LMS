import { ColumnDef } from '@tanstack/react-table';
import { defaultStyles, FileIcon } from 'react-file-icon';
import { FaFolder } from 'react-icons/fa';

import { DataTableColumnHeader } from '@/components/ui/data-table/data-table-column-header';
import { formatDateNoHours } from '@/utils/format';
import { humanFileSize } from '@/utils/format-file-size';
import { getFileExtension } from '@/utils/get-file-extension';

import { ResourceFile, ResourceFolder } from '../types/api';
import { RESOURCE } from '../types/constant';

export function getColumns(): ColumnDef<ResourceFolder | ResourceFile>[] {
  return [
    {
      accessorKey: 'name',
      header: ({ column }) => <DataTableColumnHeader column={column} title='Name' />,
      cell: ({ row }) => {
        const ext = getFileExtension(row.original.name);
        const rowName = row.original.name;

        return row.original.type === RESOURCE.FILE ? (
          <div className='flex items-center space-x-2'>
            <div className='flex size-6 items-center justify-center'>
              <FileIcon extension={ext} {...defaultStyles[ext as keyof typeof defaultStyles]} />
            </div>
            <span>{rowName}</span>
          </div>
        ) : (
          <div className='flex items-center space-x-2'>
            <FaFolder className='size-6' />
            <span>{rowName}</span>
          </div>
        );
      },
      enableHiding: false,
      enableSorting: false
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
    }
  ];
}
