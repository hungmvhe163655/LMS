import { DotsHorizontalIcon, DownloadIcon, Pencil2Icon, TrashIcon } from '@radix-ui/react-icons';
import { Row } from '@tanstack/react-table';
import { useState } from 'react';

import { Button } from '@/components/ui/button';
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuSeparator,
  DropdownMenuTrigger
} from '@/components/ui/dropdown-menu';

import { ResourceFile, ResourceFolder } from '../types/api';
import { RESOURCE } from '../types/constant';

import { DeleteFilesDialog } from './delete-resource-diaglog';
import { UpdateFolderDialog } from './update-folder-dialog';

export function DropdownActions({ row }: { row: Row<ResourceFolder | ResourceFile> }) {
  const [showUpdateTaskSheet, setShowUpdateTaskSheet] = useState(false);
  const [showDeleteTaskDialog, setShowDeleteTaskDialog] = useState(false);

  return (
    <>
      {row.original.type === RESOURCE.FOLDER && (
        <UpdateFolderDialog
          open={showUpdateTaskSheet}
          onOpenChange={setShowUpdateTaskSheet}
          folder={row.original}
        />
      )}
      {row.original.type === RESOURCE.FILE && (
        <DeleteFilesDialog
          open={showDeleteTaskDialog}
          onOpenChange={setShowDeleteTaskDialog}
          files={[row.original]}
          onSuccess={() => row.toggleSelected(false)}
        />
      )}
      <DropdownMenu>
        <DropdownMenuTrigger asChild>
          <Button
            aria-label='Open menu'
            variant='ghost'
            className='flex size-8 p-0 data-[state=open]:bg-muted'
          >
            <DotsHorizontalIcon className='size-4' aria-hidden='true' />
          </Button>
        </DropdownMenuTrigger>
        <DropdownMenuContent align='end' className='w-40'>
          <DropdownMenuItem onSelect={() => setShowDeleteTaskDialog(true)}>
            Download <DownloadIcon />
          </DropdownMenuItem>
          <DropdownMenuSeparator />
          <DropdownMenuItem onSelect={() => setShowUpdateTaskSheet(true)}>
            Edit <Pencil2Icon />
          </DropdownMenuItem>
          <DropdownMenuSeparator />
          <DropdownMenuItem onSelect={() => setShowDeleteTaskDialog(true)}>
            Delete <TrashIcon />
          </DropdownMenuItem>
        </DropdownMenuContent>
      </DropdownMenu>
    </>
  );
}
