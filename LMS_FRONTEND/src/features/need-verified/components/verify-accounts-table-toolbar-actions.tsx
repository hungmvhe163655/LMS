import { zodResolver } from '@hookform/resolvers/zod';
import { Table } from '@tanstack/react-table';
import { useForm } from 'react-hook-form';
import { useSearchParams } from 'react-router-dom';
import { z } from 'zod';

import { Button } from '@/components/ui/button';
import { Form, FormControl, FormField, FormItem, FormMessage } from '@/components/ui/form';
import { Input } from '@/components/ui/input';

import { NeedVerfiedAccount } from '../types/api';

import { ConfirmValidationDialog } from './confirm-diaglog';

const formSchema = z.object({
  searchContent: z.string()
});

interface NeedVerfiedTableToolbarActionsProps {
  table: Table<NeedVerfiedAccount>;
}

export function VerfyAccountTableToolbarActions({ table }: NeedVerfiedTableToolbarActionsProps) {
  const [searchParams, setSearchParams] = useSearchParams();

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      searchContent: searchParams.get('search_content') ?? ''
    }
  });

  function onSubmit(values: z.infer<typeof formSchema>) {
    searchParams.set('search_content', values.searchContent);
    setSearchParams(searchParams);
  }

  const userId = table.getFilteredSelectedRowModel().rows.map((row) => row.original.id);

  return (
    <div className='flex items-center justify-between gap-2'>
      {table.getFilteredSelectedRowModel().rows.length > 0 ? (
        <div className='flex'>
          <ConfirmValidationDialog
            userId={userId}
            isAccept={true}
            onSuccess={() => table.toggleAllRowsSelected(false)}
          />
          <ConfirmValidationDialog
            userId={userId}
            isAccept={false}
            onSuccess={() => table.toggleAllRowsSelected(false)}
          />
        </div>
      ) : null}
      <div>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className='flex space-x-2 p-2'>
            {/* Search */}
            <FormField
              control={form.control}
              name='searchContent'
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
