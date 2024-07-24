import { zodResolver } from '@hookform/resolvers/zod';
import { useForm } from 'react-hook-form';
import { useNavigate } from 'react-router-dom';

import { Link } from '@/components/app/link';
import RichText from '@/components/app/rich-text/rich-text';
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

import { useCreateNews } from '../api/create-news';
import {
  CONTENT_LIMIT,
  createNewsAPISchema,
  createNewsInputSchema,
  CreateNewsInputSchema
} from '../types/api';

export function CreateNewsForm() {
  const { accessData } = authStore.getState();
  const { toast } = useToast();
  const navigate = useNavigate();
  const { mutate: createNews } = useCreateNews();
  const form = useForm<CreateNewsInputSchema>({
    resolver: zodResolver(createNewsInputSchema),
    defaultValues: {
      title: '',
      content: ''
    }
  });

  function onSubmit(values: CreateNewsInputSchema) {
    const data = createNewsAPISchema.parse({
      ...values,
      createdBy: accessData?.id
    });

    createNews(data, {
      onSuccess: () => {
        navigate('/news');
        toast({
          variant: 'success',
          description: 'Save News Success'
        });
      }
    });
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
                <RichText onChange={field.onChange} value={field.value} limit={CONTENT_LIMIT} />
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
