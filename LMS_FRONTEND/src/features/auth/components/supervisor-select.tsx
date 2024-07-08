import { Popover, PopoverTrigger, PopoverContent } from '@radix-ui/react-popover';
import { CheckIcon } from 'lucide-react';
import React from 'react';
import { FaChalkboardTeacher } from 'react-icons/fa';

import { Button } from '@/components/ui/button';
import {
  Command,
  CommandEmpty,
  CommandGroup,
  CommandInput,
  CommandItem,
  CommandList
} from '@/components/ui/command';
import {
  FormControl,
  FormDescription,
  FormField,
  FormItem,
  FormLabel,
  FormMessage
} from '@/components/ui/form';
import { cn } from '@/lib/utils';

// Waiting for  API
const supervisors = [
  {
    value: 'ChiLP2',
    label: 'Lê Phương Chi (ChiLP)'
  },
  {
    value: 'SonNT',
    label: 'Ngô Tùng Sơn (SonNT)'
  },
  {
    value: 'AnhBN',
    label: 'Bùi Ngọc Anh (AnhBN)'
  }
] as const;

interface SupervisorSelectProps {
  control: any;
  name: string;
  form: any;
}

const SupervisorSelect: React.FC<SupervisorSelectProps> = ({ control, name, form }) => {
  return (
    <FormField
      control={control}
      name={name}
      render={({ field }) => (
        <FormItem className='flex flex-col'>
          <FormLabel>Supervisor</FormLabel>
          <Popover>
            <PopoverTrigger asChild>
              <FormControl>
                <Button
                  variant='outline'
                  role='combobox'
                  className={cn('justify-between', !field.value && 'text-muted-foreground')}
                >
                  {field.value
                    ? supervisors.find((supervisor) => supervisor.value === field.value)?.label
                    : 'Select supervisor'}
                  <FaChalkboardTeacher className='ml-2 size-4 shrink-0 opacity-50' />
                </Button>
              </FormControl>
            </PopoverTrigger>
            <PopoverContent className='w-96 p-0'>
              <Command>
                <CommandInput placeholder='Search Supervisor...' className='h-9' />
                <CommandEmpty>No Supervisor found.</CommandEmpty>
                <CommandGroup>
                  <CommandList>
                    {supervisors.map((supervisor) => (
                      <CommandItem
                        value={supervisor.value}
                        key={supervisor.value}
                        onSelect={() => {
                          form.setValue('verifiedBy', supervisor.value);
                        }}
                      >
                        {supervisor.label}
                        <CheckIcon
                          className={cn(
                            'ml-auto h-4 w-4',
                            supervisor.value === field.value ? 'opacity-100' : 'opacity-0'
                          )}
                        />
                      </CommandItem>
                    ))}
                  </CommandList>
                </CommandGroup>
              </Command>
            </PopoverContent>
          </Popover>
          <FormDescription>This is the Supervisor that will verify your account.</FormDescription>
          <FormMessage />
        </FormItem>
      )}
    />
  );
};

export default SupervisorSelect;
