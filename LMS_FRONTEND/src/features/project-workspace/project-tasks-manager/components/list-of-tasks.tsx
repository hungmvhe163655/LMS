// TaskList.tsx

import { zodResolver } from '@hookform/resolvers/zod';
import { CaretSortIcon, CheckIcon } from '@radix-ui/react-icons';
import { useForm } from 'react-hook-form';
import { z } from 'zod';

import { Button } from '@/components/ui/button';
import {
  Command,
  CommandEmpty,
  CommandGroup,
  CommandInput,
  CommandItem,
  CommandList
} from '@/components/ui/command';
import { Form, FormControl, FormField, FormItem, FormLabel } from '@/components/ui/form';
import { Input } from '@/components/ui/input';
import { Popover, PopoverContent, PopoverTrigger } from '@/components/ui/popover';
import { cn } from '@/lib/utils';

import { mockTasks, priorities, statuses, users } from './mock-data';

const FormSchema = z.object({
  search: z.string().optional(),
  priority: z.string().optional(),
  status: z.string().optional(),
  assignee: z.string().optional(),
  startTime: z.date().optional(),
  endTime: z.date().optional()
});

const ListOfTask = ({ onTaskClick }) => {
  const form = useForm({
    resolver: zodResolver(FormSchema)
  });

  const handleFormSubmit = (data: any) => {
    console.log('Filter data:', data);
    // Call API to fetch filtered tasks
  };

  return (
    <div className='w-1/5 p-4'>
      {/* Filter Form */}
      <Form {...form}>
        <form onSubmit={form.handleSubmit(handleFormSubmit)} className='space-y-4'>
          <FormField
            control={form.control}
            name='search'
            render={({ field }) => (
              <FormItem>
                <FormLabel>Search</FormLabel>
                <FormControl>
                  <Input {...field} placeholder='Search tasks...' />
                </FormControl>
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name='priority'
            render={({ field }) => (
              <FormItem>
                <FormLabel>Priority</FormLabel>
                <Popover>
                  <PopoverTrigger asChild>
                    <FormControl>
                      <Button
                        variant='outline'
                        role='combobox'
                        className={cn(
                          'w-full justify-between',
                          !field.value && 'text-muted-foreground'
                        )}
                      >
                        {field.value
                          ? priorities.find((p) => p.value === field.value)?.label
                          : 'Select priority'}
                        <CaretSortIcon className='ml-2 size-4 shrink-0 opacity-50' />
                      </Button>
                    </FormControl>
                  </PopoverTrigger>
                  <PopoverContent className='w-full p-0'>
                    <Command>
                      <CommandInput placeholder='Search priority...' />
                      <CommandList>
                        <CommandEmpty>No priority found.</CommandEmpty>
                        <CommandGroup>
                          {priorities.map((priority) => (
                            <CommandItem
                              key={priority.value}
                              onSelect={() => field.onChange(priority.value)}
                            >
                              {priority.label}
                              <CheckIcon
                                className={cn(
                                  'ml-auto h-4 w-4',
                                  priority.value === field.value ? 'opacity-100' : 'opacity-0'
                                )}
                              />
                            </CommandItem>
                          ))}
                        </CommandGroup>
                      </CommandList>
                    </Command>
                  </PopoverContent>
                </Popover>
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name='status'
            render={({ field }) => (
              <FormItem>
                <FormLabel>Status</FormLabel>
                <Popover>
                  <PopoverTrigger asChild>
                    <FormControl>
                      <Button
                        variant='outline'
                        role='combobox'
                        className={cn(
                          'w-full justify-between',
                          !field.value && 'text-muted-foreground'
                        )}
                      >
                        {field.value
                          ? statuses.find((s) => s.value === field.value)?.label
                          : 'Select status'}
                        <CaretSortIcon className='ml-2 size-4 shrink-0 opacity-50' />
                      </Button>
                    </FormControl>
                  </PopoverTrigger>
                  <PopoverContent className='w-full p-0'>
                    <Command>
                      <CommandInput placeholder='Search status...' />
                      <CommandList>
                        <CommandEmpty>No status found.</CommandEmpty>
                        <CommandGroup>
                          {statuses.map((status) => (
                            <CommandItem
                              key={status.value}
                              onSelect={() => field.onChange(status.value)}
                            >
                              {status.label}
                              <CheckIcon
                                className={cn(
                                  'ml-auto h-4 w-4',
                                  status.value === field.value ? 'opacity-100' : 'opacity-0'
                                )}
                              />
                            </CommandItem>
                          ))}
                        </CommandGroup>
                      </CommandList>
                    </Command>
                  </PopoverContent>
                </Popover>
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name='assignee'
            render={({ field }) => (
              <FormItem>
                <FormLabel>Assignee</FormLabel>
                <Popover>
                  <PopoverTrigger asChild>
                    <FormControl>
                      <Button
                        variant='outline'
                        role='combobox'
                        className={cn(
                          'w-full justify-between',
                          !field.value && 'text-muted-foreground'
                        )}
                      >
                        {field.value
                          ? users.find((u) => u.value === field.value)?.label
                          : 'Select assignee'}
                        <CaretSortIcon className='ml-2 size-4 shrink-0 opacity-50' />
                      </Button>
                    </FormControl>
                  </PopoverTrigger>
                  <PopoverContent className='w-full p-0'>
                    <Command>
                      <CommandInput placeholder='Search assignee...' />
                      <CommandList>
                        <CommandEmpty>No assignee found.</CommandEmpty>
                        <CommandGroup>
                          {users.map((user) => (
                            <CommandItem
                              key={user.value}
                              onSelect={() => field.onChange(user.value)}
                            >
                              {user.label}
                              <CheckIcon
                                className={cn(
                                  'ml-auto h-4 w-4',
                                  user.value === field.value ? 'opacity-100' : 'opacity-0'
                                )}
                              />
                            </CommandItem>
                          ))}
                        </CommandGroup>
                      </CommandList>
                    </Command>
                  </PopoverContent>
                </Popover>
              </FormItem>
            )}
          />
          <Button type='submit'>Filter</Button>
        </form>
      </Form>

      {/* Task List */}
      <div className='mt-4 space-y-2'>
        {mockTasks.map((task) => (
          // eslint-disable-next-line jsx-a11y/click-events-have-key-events, jsx-a11y/no-static-element-interactions
          <div key={task.id} onClick={() => onTaskClick(task)}>
            <div>
              <div>{task.title}</div>
              <div>
                <p>Priority: {task.priority}</p>
                <p>Assigned To: {task.assignedTo}</p>
                <p>Status: {task.status}</p>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default ListOfTask;
