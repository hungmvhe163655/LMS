import { zodResolver } from '@hookform/resolvers/zod';
import { useEffect, useState } from 'react';
import { useForm } from 'react-hook-form';
import { z } from 'zod';

import { useValidateEmail } from '../api/use-validate-email';
import { useValidateOtp } from '../api/use-validate-otp';

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

const FormSchema = z.object({
  pin: z.string().min(6, {
    message: 'Invalid Code'
  })
});

interface ValidateOtpFormProps {
  email: string;
  onBack: () => void;
}

export const ValidateOtpForm: React.FC<ValidateOtpFormProps> = ({ email, onBack }) => {
  const { mutate: validateOtp, isPending, error } = useValidateOtp();
  const { mutate: validateEmail } = useValidateEmail();
  const [seconds, setSeconds] = useState<number>(60);
  const [isCounting, setIsCounting] = useState<boolean>(true);

  useEffect(() => {
    let timer: NodeJS.Timeout;
    if (isCounting) {
      timer = setInterval(() => {
        setSeconds((prevSeconds) => (prevSeconds > 0 ? prevSeconds - 1 : 0));
      }, 1000);
    }

    return () => clearInterval(timer);
  }, [isCounting]);

  const handleResendOtp = () => {
    validateEmail({ email });
    setSeconds(60);
    setIsCounting(true);
  };

  const form = useForm<z.infer<typeof FormSchema>>({
    resolver: zodResolver(FormSchema),
    defaultValues: {
      pin: ''
    }
  });

  function onSubmit(data: z.infer<typeof FormSchema>) {
    const dataObject = {
      email,
      pin: data.pin
    };
    validateOtp(dataObject);
  }

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)} className='space-y-4'>
        <FormField
          control={form.control}
          name='pin'
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
              <FormDescription>We have send a code to your mail, please enter it!</FormDescription>
              <FormMessage>{error?.message || form.formState.errors.pin?.message}</FormMessage>
            </FormItem>
          )}
        />
        <div className='flex w-full'>
          <Button className='mr-5 mt-0' type='submit' disabled={isPending}>
            {isPending ? 'Sending...' : 'Send email'}
          </Button>
          <Button type='button' onClick={handleResendOtp} disabled={isCounting && seconds > 0}>
            {isCounting && seconds > 0 ? `Resend OTP in ${seconds}s` : 'Resend OTP'}
          </Button>
        </div>
        <Button
          className='w-full bg-blue-600 hover:bg-blue-800'
          type='button'
          onClick={onBack}
          disabled={isPending}
        >
          Return
        </Button>
      </form>
    </Form>
  );
};
