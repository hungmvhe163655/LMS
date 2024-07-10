import { zodResolver } from '@hookform/resolvers/zod';
import React from 'react';
import { useForm } from 'react-hook-form';
import { z } from 'zod';

import { Link } from '@/components/app/link';
import { PasswordInput } from '@/components/app/password';
import { Button } from '@/components/ui/button';
import { Checkbox } from '@/components/ui/checkbox';
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
import { RadioGroup, RadioGroupItem } from '@/components/ui/radio-group';

import { useRegister } from '../api/register';
import { registerInputSchema, Role } from '../utils/schema';

import SupervisorSelect from './supervisor-select';

interface RegisterFormProps {
  email: string;
  role: Role;
  onBack: () => void;
}

const RegisterForm: React.FC<RegisterFormProps> = ({ email, role, onBack }) => {
  const { mutate: register, isPending } = useRegister();

  const registerSchema = registerInputSchema.and(
    z.object({
      verifiedBy: z.string({
        required_error: 'Please select a supervisor.'
      }),
      rollNumber: z.string().optional()
    })
  );

  const form = useForm<z.infer<typeof registerSchema>>({
    resolver: zodResolver(registerSchema),
    defaultValues: {
      email: email,
      password: '',
      confirmPassword: '',
      fullname: '',
      phonenumber: '',
      rollNumber: '',
      role: role,
      selectGender: 'male'
    }
  });

  function onSubmit(data: z.infer<typeof registerSchema>) {
    const req = {
      ...data,
      verifiedByUserID: data.verifiedBy,
      userName: data.fullname,
      gender: data.selectGender === 'male',
      roles: [role.toLocaleLowerCase()]
    };
    register(req);
  }

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)} className='space-y-4 py-4'>
        {/* Email Input Field */}
        <FormField
          control={form.control}
          name='email'
          render={({ field }) => (
            <FormItem>
              <FormLabel>Email</FormLabel>
              <FormControl>
                <Input autoComplete='off' disabled {...field} placeholder='Email' />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Fullname input field */}
        <FormField
          control={form.control}
          name='fullname'
          render={({ field }) => (
            <FormItem>
              <FormLabel>Fullname</FormLabel>
              <FormControl>
                <Input {...field} placeholder='Full Name' />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Roll Number input field */}
        {role === 'STUDENT' && (
          <FormField
            control={form.control}
            name='rollNumber'
            render={({ field }) => (
              <FormItem>
                <FormLabel>Roll Number</FormLabel>
                <FormControl>
                  <Input {...field} placeholder='Roll Number' />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
        )}

        <FormField
          control={form.control}
          name='selectGender'
          render={({ field }) => (
            <FormItem>
              <FormLabel>Gender</FormLabel>
              <FormControl className='flex items-center space-x-6'>
                <RadioGroup onValueChange={field.onChange} defaultValue={field.value}>
                  <FormItem className='flex space-x-3 space-y-0'>
                    <FormControl>
                      <RadioGroupItem value='male' />
                    </FormControl>
                    <FormLabel className='font-normal'>Male</FormLabel>
                  </FormItem>
                  <FormItem className='flex space-x-3 space-y-0'>
                    <FormControl>
                      <RadioGroupItem value='female' />
                    </FormControl>
                    <FormLabel className='font-normal'>Female</FormLabel>
                  </FormItem>
                </RadioGroup>
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
              <SupervisorSelect form={form} field={field} name='verifiedBy' />
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
                <PasswordInput placeholder='Your password' {...field} />
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
                <PasswordInput placeholder='Confirm your password' {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        <div className='flex items-center space-x-2'>
          <Checkbox id='terms' required />
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
        <Button type='submit' className='w-full' disabled={isPending}>
          {isPending ? 'Registering...' : 'Register'}
        </Button>
        <Button className='w-full bg-blue-600 hover:bg-blue-800' type='button' onClick={onBack}>
          Return To Choose Role
        </Button>
      </form>
    </Form>
  );
};

export default RegisterForm;
