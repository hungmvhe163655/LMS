import { zodResolver } from '@hookform/resolvers/zod';
import { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { useNavigate } from 'react-router-dom';
import { z } from 'zod';

import { Link } from '@/components/app/link';
import RichText from '@/components/app/rich-text/rich-text';
import { Spinner } from '@/components/app/spinner';
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

import { useNewsById } from '../api/get-news-id';
import { useUpdateNews } from '../api/update-news';

const limit = 1000;

const formSchema = z.object({
  title: z.string().min(1).trim(),
  content: z.string().min(1).max(limit).trim()
});

export function UpdateNewsForm({ id }: { id: string }) {
  const { data, isLoading } = useNewsById({ id });
  const { toast } = useToast();
  const navigate = useNavigate();
  const { mutate: updateNews } = useUpdateNews();
  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      title: '',
      content: ''
    }
  });

  useEffect(() => {
    if (data) {
      form.reset(data);
    }
  }, [data, form]);

  function onSubmit(values: z.infer<typeof formSchema>) {
    updateNews(
      { ...values, id },
      {
        onSuccess: () => {
          navigate('/news');
          toast({
            variant: 'success',
            description: 'Update News Success'
          });
        }
      }
    );
  }

  if (isLoading) {
    return (
      <div className='flex h-48 w-full items-center justify-center'>
        <Spinner size='lg' />
      </div>
    );
  }

  return (
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

        <FormField
          control={form.control}
          name='content'
          render={({ field }) => (
            <FormItem className='flex flex-col'>
              <FormLabel className='text-xl'>Content</FormLabel>
              <FormControl>
                <RichText onChange={field.onChange} value={field.value} limit={limit} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <Button type='submit'>Submit</Button>
        <Dialog>
          <DialogTrigger asChild>
            <Button variant='outline' type='button'>
              Return to News List
            </Button>
          </DialogTrigger>
          <DialogContent className='sm:max-w-[425px]'>
            <DialogHeader>
              <DialogTitle>Exit</DialogTitle>
              <DialogDescription>
                Are you sure quit? Your change will not be save!
              </DialogDescription>
            </DialogHeader>
            <DialogFooter>
              <DialogClose asChild>
                <Button type='button' variant='secondary'>
                  Cancel
                </Button>
              </DialogClose>
              <Link variant='button' to='/news'>
                Yes
              </Link>
            </DialogFooter>
          </DialogContent>
        </Dialog>
      </form>
    </Form>
  );
}
