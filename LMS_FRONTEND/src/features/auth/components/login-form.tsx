import { zodResolver } from '@hookform/resolvers/zod';
import { useForm } from 'react-hook-form';
import { z } from 'zod';

import { Link } from '@/components/app/link';
import { PasswordInput } from '@/components/app/password';
import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardFooter, CardHeader } from '@/components/ui/card';
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage
} from '@/components/ui/form';
import { Input } from '@/components/ui/input';

import { useLogin } from '../api/login';
import { loginInputSchema } from '../utils/schema';

export const LoginForm = () => {
  const { mutateAsync: login, isPending } = useLogin();

  const form = useForm<z.infer<typeof loginInputSchema>>({
    resolver: zodResolver(loginInputSchema),
    defaultValues: {
      email: '',
      password: ''
    }
  });

  function onSubmit(data: z.infer<typeof loginInputSchema>) {
    login(data);
  }

  return (
    <Card>
      <CardHeader className='px-6 py-4'>
        <CardDescription className='mx-auto'>Welcome to SAP Lab Management System</CardDescription>
      </CardHeader>
      <CardContent className='py-0'>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className='mb-4 space-y-4'>
            {/* Email or Roll Number Input Field */}
            <FormField
              control={form.control}
              name='email'
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Email</FormLabel>
                  <FormControl>
                    <Input placeholder='Email' {...field} autoComplete='email' />
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
                    <PasswordInput {...field} placeholder='Password' />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <Button type='submit' className='w-full' disabled={isPending}>
              {isPending ? 'Logging in...' : 'Login'}
            </Button>
          </form>
        </Form>
      </CardContent>
      <CardFooter className='flex flex-col items-start space-y-1'>
        <div>
          Don&apos;t have an account? <Link to='/auth/register'>Register now!</Link>
        </div>
        <div>
          Don&apos;t remember your password?{' '}
          <Link to='/auth/forget-password'> Forget Password</Link>
        </div>
      </CardFooter>
    </Card>
  );
};

export default LoginForm;
