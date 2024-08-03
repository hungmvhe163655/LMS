import { zodResolver } from '@hookform/resolvers/zod';
import useAuthUser from 'react-auth-kit/hooks/useAuthUser';
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
import { UserLogin } from '@/types/api';

import { useChangeEmail } from '../api/change-email';

const formSchema = z.object({
  email: z.string().min(6).email('This is not a valid email.'),
  verifyCode: z.string().min(6, {
    message: 'Invalid Code'
  })
});

interface ChangeEmailFormProps {
  email: string;
  isOtpStep: boolean;
  handleEmailSubmited: (email: string) => void;
}

export function ChangeEmailForm({ email, handleEmailSubmited, isOtpStep }: ChangeEmailFormProps) {
  const { mutate: changeEmail, isPending, error } = useChangeEmail();
  const auth = useAuthUser<UserLogin>() as UserLogin;

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      email: email
    }
  });

  function onSubmit(data: z.infer<typeof formSchema>) {
    changeEmail(
      {
        email: data.email,
        userID: auth.id
      },
      {
        onSuccess: () => {
          handleEmailSubmited(data.email);
        }
      }
    );
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
                <Input disabled={isOtpStep} type='email' placeholder='New Email' {...field} />
              </FormControl>
              <FormMessage>{error?.message || form.formState.errors.email?.message}</FormMessage>
            </FormItem>
          )}
        />
        <div className='flex justify-end'>
          <Button type='submit' disabled={isPending || isOtpStep}>
            {isPending ? 'Submiting...' : 'Submit'}
          </Button>
        </div>
      </form>
    </Form>
  );
}
