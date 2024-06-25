import { zodResolver } from '@hookform/resolvers/zod';
import { CheckIcon } from 'lucide-react';
import React from 'react';
import { useForm } from 'react-hook-form';
import { FaChalkboardTeacher } from 'react-icons/fa';
import { useSearchParams } from 'react-router-dom';
import { z } from 'zod';

import { Link } from '@/components/app/link';
import { Button } from '@/components/ui/button';
import { Card, CardContent, CardFooter } from '@/components/ui/card';
import { Checkbox } from '@/components/ui/checkbox';
import {
  Command,
  CommandEmpty,
  CommandGroup,
  CommandInput,
  CommandItem
} from '@/components/ui/command';
import {
  Form,
  FormControl,
  FormDescription,
  FormField,
  FormItem,
  FormLabel,
  FormMessage
} from '@/components/ui/form';
import { Input } from '@/components/ui/input';
import { Popover, PopoverContent, PopoverTrigger } from '@/components/ui/popover';
import { registerInputSchema, useRegister } from '@/lib/auth';
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
];

const StudentRegisterForm: React.FC = () => {
  const registering = useRegister();
  const [searchParams] = useSearchParams();
  const redirectTo = searchParams.get('redirectTo');

  const registerSchema = registerInputSchema.and(
    z.object({
      verifiedBy: z.string(),
      rollNumber: z.string().min(1, 'Required')
    })
  );

  const form = useForm<z.infer<typeof registerSchema>>({
    resolver: zodResolver(registerSchema),
    defaultValues: {
      email: '',
      password: '',
      confirmPassword: '',
      fullname: '',
      verifiedBy: '',
      phonenumber: '',
      rollNumber: ''
    }
  });

  function onSubmit(data: z.infer<typeof registerSchema>) {
    registering.mutate(data);
  }

  return (
    <Card>
      <CardContent>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className='space-y-6'>
            {/* Fullname input field */}
            <FormField
              control={form.control}
              name='fullname'
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Fullname</FormLabel>
                  <FormControl>
                    <Input {...field} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />

            {/* Email Input Field */}
            <FormField
              control={form.control}
              name='email'
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Email</FormLabel>
                  <FormControl>
                    <Input {...field} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />

            {/* Phone Number Input Field */}
            <FormField
              control={form.control}
              name='phonenumber'
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Phone Number</FormLabel>
                  <FormControl>
                    <Input {...field} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />

            {/* Supervisor Input Field */}
            <FormField
              control={form.control}
              name='verifiedBy'
              render={({ field }) => (
                <FormItem className='flex flex-col'>
                  <FormLabel>Supervisor</FormLabel>
                  <Popover>
                    <PopoverTrigger asChild>
                      <FormControl>
                        <Button
                          variant='outline'
                          role='combobox'
                          className={cn(
                            'w-[200px] justify-between',
                            !field.value && 'text-muted-foreground'
                          )}
                        >
                          {field.value
                            ? supervisors.find((supervisor) => supervisor.value === field.value)
                                ?.label
                            : 'Select supervisor'}
                          <FaChalkboardTeacher className='ml-2 size-4 shrink-0 opacity-50' />
                        </Button>
                      </FormControl>
                    </PopoverTrigger>
                    <PopoverContent className='w-[200px] p-0'>
                      <Command>
                        <CommandInput placeholder='Search Supervisor...' className='h-9' />
                        <CommandEmpty>No Supervisor found.</CommandEmpty>
                        <CommandGroup>
                          {supervisors.map((supervisor) => (
                            <CommandItem
                              value={supervisor.label}
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
                        </CommandGroup>
                      </Command>
                    </PopoverContent>
                  </Popover>
                  <FormDescription>
                    This is the Supervisor that will verify your account.
                  </FormDescription>
                  <FormMessage />
                </FormItem>
              )}
            />

            {/* Password Input Field */}
            <FormField
              control={form.control}
              name='password'
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Password</FormLabel>
                  <FormControl>
                    <Input type='password' placeholder='Your password' {...field} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />

            {/* Confirm Password Input Field */}
            <FormField
              control={form.control}
              name='confirmPassword'
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Confirm Password</FormLabel>
                  <FormControl>
                    <Input type='password' placeholder='Confirm your password' {...field} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />

            <div className='flex items-center space-x-2'>
              <Checkbox id='terms' />
              <label
                htmlFor='terms'
                className='text-sm font-medium leading-none peer-disabled:cursor-not-allowed peer-disabled:opacity-70'
              >
                I agree with
                <Link to='/regulation' target='_blank'>
                  {' '}
                  Regulations Of SAP Laboratory.
                </Link>
              </label>
            </div>
            <Button type='submit' className='w-full'>
              Register
            </Button>
          </form>
        </Form>
      </CardContent>
      <CardFooter>
        <p>
          Already have an account?
          <Link
            to={`/auth/login${redirectTo ? `?redirectTo=${encodeURIComponent(redirectTo)}` : ''}`}
          >
            {' '}
            Login Here!
          </Link>
        </p>
      </CardFooter>
    </Card>
  );
};

export default StudentRegisterForm;
