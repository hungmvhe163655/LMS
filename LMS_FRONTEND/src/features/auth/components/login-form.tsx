import { zodResolver } from '@hookform/resolvers/zod';
import { useForm } from 'react-hook-form';
import { z } from 'zod';

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
          <form onSubmit={form.handleSubmit(onSubmit)} className='mb-4 space-y-3'>
            {/* Email or Roll Number Input Field */}
            <FormField
              control={form.control}
              name='emailOrRoll'
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Email Or Roll Number</FormLabel>
                  <FormControl>
                    <Input placeholder='yourname@fpt.edu.vn or HE123456' {...field} />
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
                    <Input type='password' placeholder='password' {...field} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <Button
              type='submit'
              className='mb-2 me-2 w-full rounded-lg bg-blue-700 px-5 py-2.5 text-sm font-medium text-white hover:bg-blue-800 focus:outline-none focus:ring-4 focus:ring-blue-300 dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800'
            >
              Login
            </Button>
          </form>
        </Form>
      </CardContent>
      <CardFooter>
        <p>
          Don&apos;t have an account?
          <Link to='/auth/register/choose-role'> Register now</Link>
        </p>
      </CardFooter>
    </Card>
  );
}

export default LoginForm;
