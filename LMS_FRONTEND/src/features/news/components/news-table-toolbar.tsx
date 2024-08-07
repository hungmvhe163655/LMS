import { zodResolver } from '@hookform/resolvers/zod';
import { useForm } from 'react-hook-form';
import { useLocation, useNavigate } from 'react-router-dom';
import { z } from 'zod';

import { Link } from '@/components/app/link';
import { Button } from '@/components/ui/button';
import { Form, FormControl, FormField, FormItem, FormMessage } from '@/components/ui/form';
import { Input } from '@/components/ui/input';

const formSchema = z.object({
  searchTerm: z.string().optional()
});

export function NewsTableToolbar() {
  const navigate = useNavigate();
  const location = useLocation();

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      searchTerm: new URLSearchParams(location.search).get('search_term') ?? ''
    }
  });

  function onSubmit(values: z.infer<typeof formSchema>) {
    const queryParams = new URLSearchParams();

    queryParams.set('page', '1');
    // Include the `search_term` parameter if provided
    if (values.searchTerm) {
      queryParams.set('search_term', values.searchTerm);
    }

    navigate(`${location.pathname}?${queryParams.toString()}`, {
      replace: true
    });
  }

  return (
    <div className='flex items-center justify-between gap-2'>
      <Link
        to='/news/create'
        className='rounded-lg bg-blue-700 px-5 py-2.5 text-sm font-medium text-slate-100 hover:bg-blue-800 hover:text-slate-200 hover:no-underline focus:outline-none focus:ring-4 focus:ring-blue-300'
      >
        Create News
      </Link>

      <div>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className='flex space-x-2 p-2'>
            {/* Search */}
            <FormField
              control={form.control}
              name='searchTerm'
              render={({ field }) => (
                <FormItem>
                  <FormControl>
                    <Input type='text' placeholder='Search...' {...field} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />

            <Button type='submit'>Search</Button>
          </form>
        </Form>
      </div>
    </div>
  );
}
