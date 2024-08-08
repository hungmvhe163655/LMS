import { DotsHorizontalIcon, Pencil2Icon, TrashIcon } from '@radix-ui/react-icons';
import { Row } from '@tanstack/react-table';
import { useState } from 'react';

import { Button } from '@/components/ui/button';
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuTrigger
} from '@/components/ui/dropdown-menu';

import { ResourceFile, ResourceFolder } from '../types/api';
import { RESOURCE } from '../types/constant';

import { DeleteResourceDialog } from './delete-resource-diaglog';
import { DownloadComponent } from './download-component';
import { UpdateFolderDialog } from './update-folder-dialog';

export function DropdownActions({ row }: { row: Row<ResourceFolder | ResourceFile> }) {
  const [showUpdateFolderDialog, setShowUpdateFolderDialog] = useState(false);
  const [showDeleteResourceDialog, setShowDeleteResourceDialog] = useState(false);

  function handleOnSuccess() {
    setShowDeleteResourceDialog(false);
    setShowUpdateFolderDialog(false);
  }

  return (
    <div data-no-dnd='true'>
      {row.original.type === RESOURCE.FOLDER && (
        <UpdateFolderDialog
          open={showUpdateFolderDialog}
          onOpenChange={setShowUpdateFolderDialog}
          folder={row.original}
          onSuccess={handleOnSuccess}
        />
      )}
      <DeleteResourceDialog
        open={showDeleteResourceDialog}
        onOpenChange={setShowDeleteResourceDialog}
        resource={row.original}
        onSuccess={handleOnSuccess}
      />
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
        <DropdownMenuContent align='end' className='w-40' data-no-dnd='true'>
          {row.original.type === RESOURCE.FILE && <DownloadComponent id={row.original.id} />}
          {row.original.type === RESOURCE.FOLDER && (
            <DropdownMenuItem onSelect={() => setShowUpdateFolderDialog(true)}>
              Edit <Pencil2Icon />
            </DropdownMenuItem>
          )}
          <DropdownMenuItem onClick={() => setShowDeleteResourceDialog(true)}>
            Delete <TrashIcon />
          </DropdownMenuItem>
        </DropdownMenuContent>
      </DropdownMenu>
    </div>
  );
}
