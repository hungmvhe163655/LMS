import { zodResolver } from '@hookform/resolvers/zod';
import { useForm } from 'react-hook-form';
import { z } from 'zod';

import { PasswordInput } from '@/components/app/password';
import { Button } from '@/components/ui/button';
import { Card, CardContent, CardFooter } from '@/components/ui/card';
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
import { Link } from '@/components/ui/link';

// FormSchema and Validation
const FormSchema = z
  .object({
    email: z.string().min(6, {
      message: 'Email must have more than 6 characters' // This will be shown using FormMessage
    }),
    password: z.string().min(6, { message: 'Password must have more than 6 characters' }),
    confirmPassword: z.string(),

    fullname: z.string().min(3, { message: 'Fullname must have more than 3 characters' }),
    phonenumber: z.string().min(9, { message: 'Phone number must have more than 9 characters' })
  })
  .superRefine(({ confirmPassword, password }, ctx) => {
    if (confirmPassword !== password) {
      ctx.addIssue({
        code: 'custom',
        message: 'The passwords did not match',
        path: ['confirmPassword']
      });
    }
  });

// LoginForm component
function SupervisorRegisterForm() {
  const form = useForm<z.infer<typeof FormSchema>>({
    resolver: zodResolver(FormSchema),
    defaultValues: {
      email: '',
      password: ''
    }
  });

  // onSubmit
  function onSubmit(data: z.infer<typeof FormSchema>) {
    console.log(data);
    // Submit Logic
  }

  // HTML?
  return (
    <Card>
      <CardContent className='p-6'>
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
                    <Input placeholder='Nguyen Van A' {...field} />
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
                    <Input placeholder='email@fpt.edu.vn' {...field} />
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

            {/* Password Input Field */}
            <FormField
              control={form.control}
              name='password'
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Password</FormLabel>
                  <FormControl>
                    <PasswordInput {...field} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <FormField
              control={form.control}
              name='confirmPassword'
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Confirm Password</FormLabel>
                  <FormControl>
                    <PasswordInput {...field} />
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
              Submit
            </Button>
          </form>
        </Form>
      </CardContent>
      <CardFooter>
        <p>
          Already have an account?
          <Link to='/'> Login Here!</Link>
        </p>
      </CardFooter>
    </Card>
  );
}

export default SupervisorRegisterForm;
