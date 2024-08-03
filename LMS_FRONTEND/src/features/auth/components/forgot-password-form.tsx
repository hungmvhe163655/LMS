import { zodResolver } from '@hookform/resolvers/zod';
import { useState } from 'react';
import { useForm } from 'react-hook-form';
import { z } from 'zod';

import { Link } from '@/components/app/link';
import { Button } from '@/components/ui/button';
import { Card, CardContent } from '@/components/ui/card';
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage
} from '@/components/ui/form';
import { Input } from '@/components/ui/input';

import { useForgetPassword } from '../api/forget-password';

// FormSchema and Validation
const FormSchema = z.object({
  email: z.string().email()
});

function ForgotPassword() {
  const { mutate: forgetPassword, isPending, error } = useForgetPassword();
  const [isSucces, setIsSuccess] = useState<boolean>(false);

  const form = useForm<z.infer<typeof FormSchema>>({
    resolver: zodResolver(FormSchema),
    defaultValues: {
      email: ''
    }
  });

  if (isSucces) {
    return (
      <Card>
        <CardContent className='p-4'>
          <p className='text-red-600'>
            We have send New Password to your email, please use that password to login!
          </p>
          <p className='mt-2'>
            Return to <Link to='/'>Login</Link>
          </p>
        </CardContent>
      </Card>
    );
  }

  function onSubmit(data: z.infer<typeof FormSchema>) {
    forgetPassword(data.email, {
      onSuccess: () => {
        setIsSuccess(() => true);
      }
    });
  }
  return (
    <Card>
      <CardContent className='p-4'>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className='space-y-4'>
            {/* Email Input Field */}
            <FormField
              control={form.control}
              name='email'
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Email</FormLabel>
                  <FormControl>
                    <Input placeholder='Your email...' {...field} />
                  </FormControl>
                  <FormMessage>
                    {error?.message || form.formState.errors.email?.message}
                  </FormMessage>
                </FormItem>
              )}
            />

            <Button className='mt-0' type='submit' disabled={isPending}>
              {isPending ? 'Sending...' : 'Send New Password'}
            </Button>
          </form>
        </Form>
        <p className='mt-4'>
          Return to <Link to='/'>Login</Link>
        </p>
      </CardContent>
    </Card>
  );
}
export default ForgotPassword;
