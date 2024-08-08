import { zodResolver } from '@hookform/resolvers/zod';
import { useState } from 'react';
import { useForm } from 'react-hook-form';
import { useParams } from 'react-router-dom';

import { Button } from '@/components/ui/button';
import {
  Dialog,
  DialogClose,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger
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

import { useCreateFolder } from '../api/create-folder';
import {
  createFolderAPISchema,
  createFolderInputSchema,
  CreateFolderInputSchema
} from '../types/api';

export function CreateFolderDialog() {
  const { folderId } = useParams() as { folderId: string };
  const [isOpen, setIsOpen] = useState(false);

  const { toast } = useToast();
  const { mutate: createFolder, isPending } = useCreateFolder();
  const form = useForm<CreateFolderInputSchema>({
    resolver: zodResolver(createFolderInputSchema),
    defaultValues: {
      name: ''
    }
  });

  function onSubmit(values: CreateFolderInputSchema) {
    const data = createFolderAPISchema.parse({
      ...values,
      ancestorId: folderId
    });

    createFolder(data, {
      onSuccess: () => {
        setIsOpen(false);
        toast({
          variant: 'success',
          description: 'Create Folders Success'
        });
      }
    });
  }

  return (
    <Dialog open={isOpen} onOpenChange={setIsOpen}>
      <DialogTrigger asChild>
        <Button variant='outline'>Create Folder</Button>
      </DialogTrigger>
      <DialogContent className='sm:max-w-[425px]'>
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
            <Button type='submit' disabled={isPending}>
              Create
            </Button>
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
