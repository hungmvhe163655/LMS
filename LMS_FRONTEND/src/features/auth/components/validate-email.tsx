import { zodResolver } from '@hookform/resolvers/zod';
import React, { useState } from 'react';
import { useForm } from 'react-hook-form';
import { useSearchParams } from 'react-router-dom';
import { z } from 'zod';

import { Button } from '@/components/ui/button';
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle
} from '@/components/ui/card';
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage
} from '@/components/ui/form';
import { Input } from '@/components/ui/input';
import {
  InputOTP,
  InputOTPGroup,
  InputOTPSeparator,
  InputOTPSlot
} from '@/components/ui/input-otp';

import { verifyEmail, resendVerifyEmail } from '../api/auth';

// FormSchema and Validation
const FormSchema = z.object({
  email: z.string().min(6, {
    message: 'Email must have more than 6 characters'
  })
});

const ValidateEmail: React.FC = () => {
  const [searchParams] = useSearchParams();
  const [otp, setOtp] = useState('');
  const [error, setError] = useState<string | null>(null);

  const form = useForm<z.infer<typeof FormSchema>>({
    resolver: zodResolver(FormSchema),
    defaultValues: {
      email: searchParams.get('email') || ''
    }
  });

  const handleOtpChange = async (value: string) => {
    setOtp(value);

    if (value.length === 6) {
      try {
        const _response = await verifyEmail(form.getValues('email'), value);
        alert('Success');
      } catch (err) {
        if (err instanceof Error) {
          setError(err.message);
        } else {
          setError('An unknown error occurred');
        }
      }
    }
  };

  const handleResendEmail = async () => {
    try {
      const _response = await resendVerifyEmail(form.getValues('email'));
      alert('New Verify code has been sent to your email');
    } catch (err) {
      if (err instanceof Error) {
        setError(err.message);
      } else {
        setError('An unknown error occurred');
      }
    }
  };

  return (
    <div>
      <Card className='card'>
        <CardHeader>
          <CardTitle>Login</CardTitle>
          <CardDescription>Welcome to SAP Lab Management System</CardDescription>
        </CardHeader>
        <CardContent className='card-content'>
          <Form {...form}>
            <form className='w-2/3 space-y-6'>
              {/* Email Input Field */}
              <FormField
                control={form.control}
                name='email'
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Email</FormLabel>
                    <FormControl>
                      <Input placeholder='example@gmail.com' {...field} />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
              {/* OTP Input Field */}
              <FormItem>
                <FormLabel>OTP</FormLabel>
                <FormControl>
                  <InputOTP maxLength={6} value={otp} onChange={handleOtpChange}>
                    <InputOTPGroup>
                      <InputOTPSlot index={0} />
                      <InputOTPSlot index={1} />
                      <InputOTPSlot index={2} />
                    </InputOTPGroup>
                    <InputOTPSeparator />
                    <InputOTPGroup>
                      <InputOTPSlot index={3} />
                      <InputOTPSlot index={4} />
                      <InputOTPSlot index={5} />
                    </InputOTPGroup>
                  </InputOTP>
                </FormControl>
                <FormMessage />
              </FormItem>
              {error && <div className='text-red-500'>{error}</div>}
              <Button type='button' onClick={handleResendEmail}>
                Send email
              </Button>
            </form>
          </Form>
        </CardContent>
        <CardFooter></CardFooter>
      </Card>
    </div>
  );
};

export default ValidateEmail;
