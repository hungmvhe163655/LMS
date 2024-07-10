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

import { useValidateEmail } from '../api/validate-email';

const FormSchema = z.object({
  email: z.string().min(6, {
    message: 'Email must have more than 6 characters'
  })
});

interface ValidateEmailFormProps {
  onSubmit: (email: string) => void;
}

const ValidateEmailForm: React.FC<ValidateEmailFormProps> = ({ onSubmit }) => {
  const { mutateAsync: validateEmail, isPending, error } = useValidateEmail();
  const form = useForm<z.infer<typeof FormSchema>>({
    resolver: zodResolver(FormSchema),
    defaultValues: {
      email: ''
    }
  });

  async function handleSubmit(data: z.infer<typeof FormSchema>) {
    await validateEmail(data, { onSuccess: () => onSubmit(data.email) });
  }

  return (
    <div>
      <Form {...form}>
        <form onSubmit={form.handleSubmit(handleSubmit)} className='w-full space-y-4'>
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
                <FormMessage>{error?.message || form.formState.errors.email?.message}</FormMessage>
              </FormItem>
            )}
          />
          <Button className='mt-0' type='submit' disabled={isPending}>
            {isPending ? 'Sending...' : 'Send email'}
          </Button>
        </form>
      </Form>
    </div>
  );
};

export default ValidateEmailForm;
