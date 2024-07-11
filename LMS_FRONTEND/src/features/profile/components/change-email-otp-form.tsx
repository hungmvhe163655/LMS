import { zodResolver } from '@hookform/resolvers/zod';
import useAuthUser from 'react-auth-kit/hooks/useAuthUser';
import { useForm } from 'react-hook-form';
import { Navigate } from 'react-router-dom';
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
import { InputOTP, InputOTPGroup, InputOTPSlot } from '@/components/ui/input-otp';
import { useToast } from '@/components/ui/use-toast';
import useCountdown from '@/hooks/use-count-down';
import { UserLogin } from '@/types/api';

import { useChangeEmail } from '../api/change-email';
import { useChangeEmailOtp } from '../api/change-email-otp';

const formSchema = z.object({
  verifyCode: z.string().min(6, {
    message: 'Invalid Code'
  })
});

interface ChangeEmailOtpFormProps {
  email: string;
  handleReSubmited: () => void;
}

export function ChangeEmailOtpForm({ email, handleReSubmited }: ChangeEmailOtpFormProps) {
  const { mutate: changeEmailOtp, isPending, error } = useChangeEmailOtp();
  const { mutate: changeEmail, isPending: isPendingResend, error: errorResend } = useChangeEmail();
  const { toast } = useToast();
  const auth = useAuthUser<UserLogin>() as UserLogin;
  const { seconds, reset } = useCountdown(60);

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema)
  });

  if (!auth) {
    return <Navigate to='/' />;
  }

  function handleResendOtp() {
    reset();
    changeEmail(
      {
        email: email,
        userID: auth.id
      },
      {
        onSuccess: () => {
          toast({
            variant: 'success',
            description: 'Send OTP Success!'
          });
          form.reset();
        }
      }
    );
  }

  function onSubmit(data: z.infer<typeof formSchema>) {
    changeEmailOtp(
      {
        userID: auth.id,
        email: email,
        token: data.verifyCode
      },
      {
        onSuccess: () => {
          toast({
            variant: 'success',
            description: 'Change email Success!'
          });
          form.reset();
        }
      }
    );
  }

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)} className='mx-16 w-1/4 min-w-fit space-y-3 p-3'>
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
                We have send a code to <span className='font-bold'>{email}</span>
              </FormDescription>
              <FormMessage>
                {error?.message ||
                  errorResend?.message ||
                  form.formState.errors.verifyCode?.message}
              </FormMessage>
            </FormItem>
          )}
        />

        <div className='flex justify-end'>
          <Button
            type='submit'
            onClick={handleResendOtp}
            disabled={isPending || isPendingResend || seconds > 0}
          >
            {seconds > 0 ? `Resend OTP in ${seconds}s` : 'Send OTP'}
          </Button>
          <Button type='button' onClick={handleReSubmited}>
            Change Email
          </Button>
        </div>
      </form>
    </Form>
  );
}
