import { CheckIcon } from 'lucide-react';
import React, { useEffect, useState } from 'react';
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
import { FormControl } from '@/components/ui/form';
import { Popover, PopoverContent, PopoverTrigger } from '@/components/ui/popover';
import { cn } from '@/lib/utils';

import { useSupervisors } from '../api/get-supervisors';
import { Supervisor } from '../utils/schema';

interface SupervisorSelectProps {
  form: any;
  field: any;
  name: string;
}

const SupervisorSelect: React.FC<SupervisorSelectProps> = ({ form, field, name }) => {
  const { data, isLoading } = useSupervisors();
  const [open, setOpen] = React.useState(false);
  const [supervisors, setSupervisors] = useState<{ value: string; label: string }[]>([]);

  useEffect(() => {
    if (data) {
      const mappedSupervisors = data.map((supervisor: Supervisor) => ({
        value: supervisor.id,
        label: supervisor.fullName
      }));
      setSupervisors(mappedSupervisors);
    }
  }, [data]);

  if (isLoading) {
    return <div>Loading...</div>;
  }

  return (
    <Popover open={open} onOpenChange={setOpen}>
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
        <Command
          filter={(value, search, keyword) => {
            const extendValue = value + ' ' + keyword?.join(' ');
            if (extendValue.includes(search)) return 1;
            return 0;
          }}
        >
          <CommandInput placeholder='Search Supervisor...' className='h-9' />
          <CommandEmpty>No Supervisor found.</CommandEmpty>
          <CommandGroup>
            <CommandList>
              {supervisors.map((supervisor) => (
                <CommandItem
                  value={supervisor.value}
                  key={supervisor.value}
                  keywords={[supervisor.label]}
                  onSelect={() => {
                    form.setValue(name, supervisor.value);
                    setOpen(false);
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
  );
};

export default SupervisorSelect;
