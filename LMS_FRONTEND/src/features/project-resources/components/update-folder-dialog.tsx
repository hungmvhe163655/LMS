import { Row } from '@tanstack/react-table';

import { Button } from '@/components/ui/button';
import {
  Dialog,
  DialogClose,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle
} from '@/components/ui/dialog';

import { ResourceFolder } from '../types/api';

interface UpdateFolderDialogProps extends React.ComponentPropsWithoutRef<typeof Dialog> {
  folder: Row<ResourceFolder>['original'];
}

export function UpdateFolderDialog({ folder, ...props }: UpdateFolderDialogProps) {
  return (
    <Dialog {...props}>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>Update Folder</DialogTitle>
          <DialogDescription>You are updating folder</DialogDescription>
        </DialogHeader>
        <DialogFooter className='gap-2 sm:space-x-0'>
          <DialogClose asChild>
            <Button variant='outline'>Cancel</Button>
          </DialogClose>
          <Button aria-label='Update selected folder' variant='destructive'>
            Update
          </Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
}
