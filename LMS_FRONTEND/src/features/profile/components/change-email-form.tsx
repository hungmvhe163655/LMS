/* import { zodResolver } from '@hookform/resolvers/zod';
import { useForm } from 'react-hook-form';
import { z } from 'zod';

import { Button } from '@/components/ui/button';
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
import { InputOTP, InputOTPGroup, InputOTPSlot } from '@/components/ui/input-otp';
import { useChangeEmail } from '../api/change-email';
import { useToast } from '@/components/ui/use-toast';
import { User } from '@/types/api';
import useAuthUser from 'react-auth-kit/hooks/useAuthUser';
import useCountdown from '@/hooks/use-count-down';
import { useState } from 'react';

const formSchema = z.object({
  email: z.string().min(6).email('This is not a valid email.'),
  verifyCode: z.string().min(6, {
    message: 'Invalid Code'
  })
});

export function ChangeEmailForm() {
  const { mutate: changeEmail, isPending, error } = useChangeEmail();
  const [isSendCode, setIsSendCode] = useState<boolean>(false);
  const { toast } = useToast();
  const auth = useAuthUser<User>() as User;
  const { seconds, reset } = useCountdown(60);

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      email: ''
    }
  });

  function onSubmit(data: z.infer<typeof formSchema>) {
    changeEmail({
      email: data.email,
      userID: auth.id,
      verifyCode: data.verifyCode
    });
  }

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)} className='mx-16 w-1/4 min-w-fit space-y-3 p-3'>
        <FormField
          control={form.control}
          name='email'
          render={({ field }) => (
            <FormItem>
              <FormLabel>New Email</FormLabel>
              <FormControl>
                <Input type='email' placeholder='New Email' {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name='verifyCode'
          render={({ field }) => (
            <FormItem>
              <FormLabel>Verify Code</FormLabel>
              <FormControl>
                <InputOTP maxLength={6} {...field}>
                  <InputOTPGroup>
                    <InputOTPSlot index={0} />
                    <InputOTPSlot index={1} />
                    <InputOTPSlot index={2} />
                    <InputOTPSlot index={3} />
                    <InputOTPSlot index={4} />
                    <InputOTPSlot index={5} />
                  </InputOTPGroup>
                </InputOTP>
              </FormControl>
              <FormDescription>
                We have send a code to <span className='font-bold'>{form.formState}</span>
              </FormDescription>
              <FormMessage>
                {error?.message || form.formState.errors.verifyCode?.message}
              </FormMessage>
            </FormItem>
          )}
        />

        <div className='flex justify-end'>
          <Button type='button' onClick={handleResendOtp} disabled={seconds > 0}>
            {seconds > 0 ? `Resend OTP in ${seconds}s` : 'Send OTP'}
          </Button>
        </div>
      </form>
    </Form>
  );
}
*/
