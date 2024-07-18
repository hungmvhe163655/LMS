// TaskDetail.tsx

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

// import { DatePickerWithRange } from './date-picker';
import { priorities, statuses, users } from './mock-data';

const FormSchema = z.object({
  title: z.string().nonempty({ message: 'Title is required' }),
  priority: z.string().optional(),
  status: z.string().optional(),
  assignee: z.string().optional(),
  startTime: z.date().optional(),
  endTime: z.date().optional()
});

const TaskDetail = ({ task }: { task: any }) => {
  const form = useForm({
    resolver: zodResolver(FormSchema),
    defaultValues: task
  });

  const handleFormSubmit = (data: any) => {
    console.log('Task data:', data);
    // Call API to update task
  };

  return (
    <div className='w-4/5 p-4'>
      {/* Task Detail Form */}
      <Form {...form}>
        <form onSubmit={form.handleSubmit(handleFormSubmit)} className='space-y-4'>
          <FormField
            control={form.control}
            name='title'
            render={({ field }) => (
              <FormItem>
                <FormLabel>Title</FormLabel>
                <FormControl>
                  <Input {...field} placeholder='Task title' />
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
          {/* <FormField
            control={form.control}
            name='startTime'
            render={({ field }) => (
              <FormItem>
                <FormLabel>Start Time</FormLabel>
                <DatePickerWithRange
                //   selected={field.value}
                //   onSelect={(date: any) => field.onChange(date)}
                />
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name='endTime'
            render={({ field }) => (
              <FormItem>
                <FormLabel>End Time</FormLabel>
                <DatePickerWithRange
                //   selected={field.value}
                //   onSelect={(date: any) => field.onChange(date)}
                />
              </FormItem>
            )}
          /> */}
          <Button type='submit'>Save</Button>
        </form>
      </Form>
    </div>
  );
};

export default TaskDetail;
