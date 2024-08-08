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
import { useToast } from '@/components/ui/use-toast';

import { useDeleteFile } from '../api/delete-files';
import { useDeleteFolder } from '../api/delete-folder';
import { ResourceFile, ResourceFolder } from '../types/api';
import { RESOURCE } from '../types/constant';

interface DeleteResourceDialogProps extends React.ComponentPropsWithoutRef<typeof Dialog> {
  resource: Row<ResourceFile | ResourceFolder>['original'];
  onSuccess?: () => void;
}

export function DeleteResourceDialog({ resource, onSuccess, ...props }: DeleteResourceDialogProps) {
  const { mutate: deleteFolder, isPending: isDeletingFolder } = useDeleteFolder();
  const { toast } = useToast();
  const { mutate: deleteFile, isPending: isDeletingFile } = useDeleteFile();

  function handleDelete() {
    if (resource.type === RESOURCE.FOLDER) {
      deleteFolder(
        { id: resource.id },
        {
          onSuccess: () => {
            toast({
              variant: 'success',
              description: 'Delete Folder Success'
            });
            onSuccess?.();
          }
        }
      );
    } else if (resource.type === RESOURCE.FILE) {
      deleteFile(
        { id: resource.id },
        {
          onSuccess: () => {
            toast({
              variant: 'success',
              description: 'Delete File Success'
            });
            onSuccess?.();
          }
        }
      );
    }
  }

  return (
    <Dialog {...props}>
      <DialogContent data-no-dnd='true'>
        <DialogHeader>
          <DialogTitle>Are you absolutely sure?</DialogTitle>
          <DialogDescription>
            This action cannot be undone. This will permanently delete your resource.
          </DialogDescription>
        </DialogHeader>
        <DialogFooter className='gap-2 sm:space-x-0'>
          <DialogClose asChild>
            <Button variant='outline'>Cancel</Button>
          </DialogClose>
          <Button
            aria-label='Delete selected rows'
            variant='destructive'
            onClick={handleDelete}
            disabled={isDeletingFile || isDeletingFolder}
          >
            Delete
          </Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
}
