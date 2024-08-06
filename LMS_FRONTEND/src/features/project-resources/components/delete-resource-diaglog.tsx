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

import { ResourceFile } from '../types/api';

interface DeleteFilesDialogProps extends React.ComponentPropsWithoutRef<typeof Dialog> {
  files: Row<ResourceFile>['original'][];
  onSuccess?: () => void;
}

export function DeleteFilesDialog({ files, onSuccess, ...props }: DeleteFilesDialogProps) {
  return (
    <Dialog {...props}>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>Are you absolutely sure?</DialogTitle>
          <DialogDescription>
            This action cannot be undone. This will permanently delete your
            <span className='font-medium'>{files.length}</span>
            {files.length === 1 ? ' file' : ' files'} from our servers.
          </DialogDescription>
        </DialogHeader>
        <DialogFooter className='gap-2 sm:space-x-0'>
          <DialogClose asChild>
            <Button variant='outline'>Cancel</Button>
          </DialogClose>
          <Button aria-label='Delete selected rows' variant='destructive'>
            Delete
          </Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
}
