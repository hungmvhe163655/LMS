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
import { authStore } from '@/lib/auth-store';

import { useCreateFolder } from '../api/create-folder';
import {
  createFolderAPISchema,
  createFolderInputSchema,
  CreateFolderInputSchema
} from '../types/api';

export function CreateFolderDialog() {
  const { accessData } = authStore.getState();
  const { folderId } = useParams() as { folderId: string };
  const { projectId } = useParams() as { projectId: string };
  const [isOpen, setIsOpen] = useState(false);

  const { toast } = useToast();
  const { mutate: createFolder } = useCreateFolder();
  const form = useForm<CreateFolderInputSchema>({
    resolver: zodResolver(createFolderInputSchema),
    defaultValues: {
      title: ''
    }
  });

  function onSubmit(values: CreateFolderInputSchema) {
    const data = createFolderAPISchema.parse({
      ...values,
      createdBy: accessData?.id,
      projectId: projectId,
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
              name='title'
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
            <Button type='submit'>Create</Button>
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
