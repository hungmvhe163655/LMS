import { zodResolver } from '@hookform/resolvers/zod';
import { useForm } from 'react-hook-form';
import { z } from 'zod';

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
import { Link } from '@/components/ui/link';

// FormSchema and Validation
const FormSchema = z.object({
  emailOrRoll: z.string().min(6, {
    message: 'Email or roll number must have more than 6 characters' // This will be shown using FormMessage
  }),
  password: z.string().min(6, { message: 'Password must have more than 6 characters' })
});

// LoginForm component
function LoginForm() {
  const form = useForm<z.infer<typeof FormSchema>>({
    resolver: zodResolver(FormSchema),
    defaultValues: {
      emailOrRoll: '',
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
      <CardHeader className='px-6 py-4'>
        <CardDescription className='mx-auto'>Welcome to SAP Lab Management System</CardDescription>
      </CardHeader>
      <CardContent className='py-0'>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className='mb-4 space-y-4'>
            {/* Email or Roll Number Input Field */}
            <FormField
              control={form.control}
              name='emailOrRoll'
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Email Or Roll Number</FormLabel>
                  <FormControl>
                    <Input
                      placeholder='yourname@fpt.edu.vn or HE123456'
                      {...field}
                      autoComplete='email'
                    />
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
            <Button type='submit' className='w-full'>
              Login
            </Button>
          </form>
        </Form>
      </CardContent>
      <CardFooter className='flex-col space-y-2'>
        <p>
          Don&apos;t have an account? <Link to='/auth/register/choose-role'>Register now!</Link>
        </p>
        <p>
          Don&apos;t remember your password?{' '}
          <Link to='/auth/forget-password'> Forget Password</Link>
        </p>
      </CardFooter>
    </Card>
  );
}

export default LoginForm;
