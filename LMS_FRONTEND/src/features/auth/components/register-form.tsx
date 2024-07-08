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
  FormField,
  FormItem,
  FormLabel,
  FormMessage
} from '@/components/ui/form';
import { Input } from '@/components/ui/input';
import { RadioGroup, RadioGroupItem } from '@/components/ui/radio-group';

import { useRegister } from '../api/use-register';
import { registerInputSchema, Role } from '../utils/schema';

import SupervisorSelect from './supervisor-select';

interface RegisterFormProps {
  email: string;
  role: Role;
}

const RegisterForm: React.FC<RegisterFormProps> = ({ email, role }) => {
  const { mutateAsync: register, isPending } = useRegister();

  const registerSchema = registerInputSchema.and(
    z.object({
      verifiedBy: z.string({
        required_error: 'Please select a supervisor.'
      }),
      rollNumber: z.string().min(1, 'Required'),
      selectGender: z.enum(['male', 'female'])
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

  console.log(form.formState.errors);

  async function onSubmit(data: z.infer<typeof registerSchema>) {
    data.gender = data.selectGender === 'male';
    await register(data);
  }

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)} className='space-y-6 py-4'>
        {/* Email Input Field */}
        <FormField
          control={form.control}
          name='email'
          render={({ field }) => (
            <FormItem>
              <FormLabel>Email</FormLabel>
              <FormControl>
                <Input disabled {...field} placeholder='Email' />
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
        {role === 'STUDENT' && (
          <SupervisorSelect control={form.control} name='verifiedBy' form={form} />
        )}

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
      </form>
    </Form>
  );
};

export default RegisterForm;
