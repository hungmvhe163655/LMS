import { zodResolver } from '@hookform/resolvers/zod';
import { useForm } from 'react-hook-form';
import { z } from 'zod';

import { Button } from '@/components/ui/button';
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage
} from '@/components/ui/form';
import { Input } from '@/components/ui/input';
import { InputOTP, InputOTPGroup, InputOTPSlot } from '@/components/ui/input-otp';

const formSchema = z.object({
  phoneNumber: z.string().regex(/^0\d{9}$/, {
    message: 'Invalid Phone Number'
  })
});

export function ChangePhoneNumberForm() {
  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      phoneNumber: ''
    }
  });

  function onSubmit(data: z.infer<typeof formSchema>) {
    console.log(data);
  }

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)} className='mx-16 w-1/4 min-w-fit space-y-3 p-3'>
        <FormField
          control={form.control}
          name='phoneNumber'
          render={({ field }) => (
            <FormItem>
              <FormLabel>New Phone Number</FormLabel>
              <FormControl>
                <Input type='text' placeholder='New Phone Number' {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <div className='space-y-3'>
          <InputOTP maxLength={6}>
            <InputOTPGroup>
              <InputOTPSlot index={0} />
              <InputOTPSlot index={1} />
              <InputOTPSlot index={2} />

              <InputOTPSlot index={3} />
              <InputOTPSlot index={4} />
              <InputOTPSlot index={5} />
            </InputOTPGroup>
          </InputOTP>
          <div className='flex justify-end'>
            <Button type='submit'>Confirm</Button>
          </div>
        </div>
      </form>
    </Form>
  );
}
