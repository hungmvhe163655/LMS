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

import { useUploadFile } from '../api/upload-file';
import { uploadFileInputSchema, UploadFileInputSchema } from '../types/api';

export function UploadFileDialog() {
  const { folderId } = useParams() as { folderId: string };
  const [isOpen, setIsOpen] = useState(false);

  const { toast } = useToast();
  const { mutate: uploadFile, isPending } = useUploadFile();
  const form = useForm<UploadFileInputSchema>({
    resolver: zodResolver(uploadFileInputSchema),
    defaultValues: {
      file: undefined
    }
  });

  function onSubmit(values: UploadFileInputSchema) {
    const data = {
      ...values,
      folderId
    };

    uploadFile(data, {
      onSuccess: () => {
        setIsOpen(false);
        toast({
          variant: 'success',
          description: 'File Uploaded Successfully'
        });
      }
    });
  }

  return (
    <Dialog open={isOpen} onOpenChange={setIsOpen}>
      <DialogTrigger asChild>
        <Button variant='outline'>Upload File</Button>
      </DialogTrigger>
      <DialogContent className='sm:max-w-[425px]'>
        <DialogHeader>
          <DialogTitle>Upload File</DialogTitle>
          <DialogDescription>Upload a file to the selected folder.</DialogDescription>
        </DialogHeader>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className='flex flex-1 flex-col space-y-3'>
            {/* File Input */}
            <FormField
              control={form.control}
              name='file'
              // eslint-disable-next-line @typescript-eslint/no-unused-vars
              render={({ field: { value, onChange, ...fieldProps } }) => (
                <FormItem>
                  <FormLabel className='text-xl'>File</FormLabel>
                  <FormControl>
                    <Input
                      type='file'
                      {...fieldProps}
                      onChange={(event) => onChange(event.target.files && event.target.files[0])}
                    />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <Button type='submit' disabled={isPending}>
              Upload
            </Button>
          </form>
        </Form>
        <DialogFooter className='w-full sm:justify-start'>
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
