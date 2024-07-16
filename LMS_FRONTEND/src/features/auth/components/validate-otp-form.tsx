import { zodResolver } from '@hookform/resolvers/zod';
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
import { InputOTP, InputOTPGroup, InputOTPSlot } from '@/components/ui/input-otp';
import useCountdown from '@/hooks/use-count-down';

import { useValidateEmail } from '../api/validate-email';
import { useValidateOtp } from '../api/validate-otp';

const FormSchema = z.object({
  pin: z.string().min(6, {
    message: 'Invalid Code'
  })
});

interface ValidateOtpFormProps {
  email: string;
  onBack: () => void;
  onValidate: () => void;
}

export const ValidateOtpForm: React.FC<ValidateOtpFormProps> = ({ email, onBack, onValidate }) => {
  const { mutate: validateOtp, isPending, error } = useValidateOtp();
  const { mutate: validateEmail, isPending: isPendingResend } = useValidateEmail();
  const { seconds, reset } = useCountdown(60);

  const handleResendOtp = () => {
    validateEmail({ email });
    reset();
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
      auCode: data.pin
    };
    validateOtp(dataObject, { onSuccess: () => onValidate() });
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
                <InputOTP className='justify-center' maxLength={6} {...field}>
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
              <FormMessage>{error?.message || form.formState.errors.pin?.message}</FormMessage>
            </FormItem>
          )}
        />
        <div className='flex w-full justify-between'>
          <Button
            className=' bg-blue-600 hover:bg-blue-800'
            type='button'
            onClick={onBack}
            disabled={isPending || isPendingResend}
          >
            Return
          </Button>
          <Button type='button' onClick={handleResendOtp} disabled={seconds > 0 || isPendingResend}>
            {seconds > 0 ? `Resend OTP in ${seconds}s` : 'Resend OTP'}
          </Button>
        </div>

        <Button className='mr-5 mt-0 w-full' type='submit' disabled={isPending}>
          {isPending ? 'Sending...' : 'Submit'}
        </Button>
      </form>
    </Form>
  );
};
