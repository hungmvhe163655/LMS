import { zodResolver } from '@hookform/resolvers/zod';
import { useForm } from 'react-hook-form';
import { useSearchParams } from 'react-router-dom';
import { z } from 'zod';

import { Link } from '@/components/app/link';
import { Button } from '@/components/ui/button';
import { Form, FormControl, FormField, FormItem, FormMessage } from '@/components/ui/form';
import { Input } from '@/components/ui/input';

const formSchema = z.object({
  searchTerm: z.string()
});

export function VerfyAccountTableToolbarActions() {
  const [searchParams, setSearchParams] = useSearchParams();

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      searchTerm: searchParams.get('searchTerm') ?? ''
    }
  });

  function onSubmit(values: z.infer<typeof formSchema>) {
    searchParams.set('searchTerm', values.searchTerm);
    setSearchParams(searchParams);
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
