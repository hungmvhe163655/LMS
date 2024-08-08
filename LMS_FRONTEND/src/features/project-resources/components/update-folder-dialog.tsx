import { zodResolver } from '@hookform/resolvers/zod';
import { Row } from '@tanstack/react-table';
import { useForm } from 'react-hook-form';

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
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage
} from '@/components/ui/form';
import { Input } from '@/components/ui/input';
import { useToast } from '@/components/ui/use-toast';

import { useUpdateFolder } from '../api/update-folder';
import {
  createFolderInputSchema,
  CreateFolderInputSchema,
  ResourceFolder,
  updateFolderAPISchema
} from '../types/api';

interface UpdateFolderDialogProps extends React.ComponentPropsWithoutRef<typeof Dialog> {
  folder: Row<ResourceFolder>['original'];
  onSuccess?: () => void;
}

export function UpdateFolderDialog({ folder, onSuccess, ...props }: UpdateFolderDialogProps) {
  const { toast } = useToast();
  const { mutate: updateFolder } = useUpdateFolder();
  const form = useForm<CreateFolderInputSchema>({
    resolver: zodResolver(createFolderInputSchema),
    defaultValues: {
      name: folder.name
    }
  });

  function onSubmit(values: CreateFolderInputSchema) {
    const data = updateFolderAPISchema.parse({
      ...values,
      id: folder.id
    });

    updateFolder(data, {
      onSuccess: () => {
        toast({
          variant: 'success',
          description: 'Create Folders Success'
        });
        onSuccess?.();
      }
    });
  }

  return (
    <Dialog {...props}>
      <DialogContent className='sm:max-w-[425px]' data-no-dnd='true'>
        <DialogHeader>
          <DialogTitle>Create Folder</DialogTitle>
          <DialogDescription>Create a folder, the folder will appear above.</DialogDescription>
        </DialogHeader>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className='flex flex-1 flex-col space-y-3'>
            {/* Title */}
            <FormField
              control={form.control}
              name='name'
              render={({ field }) => (
                <FormItem>
                  <FormLabel className='text-xl'>Title</FormLabel>
                  <FormControl>
                    <Input type='text' {...field} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <Button type='submit'>Update</Button>
          </form>
        </Form>
        <DialogFooter className='sm:justify-start'>
          <DialogClose asChild>
            <Button type='button' variant='secondary'>
              Close
            </Button>
          </DialogClose>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
}
