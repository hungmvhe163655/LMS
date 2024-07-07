// import { useState } from 'react';
import { zodResolver } from '@hookform/resolvers/zod';
import { useForm } from 'react-hook-form';
import { z } from 'zod';

import { useValidateEmail } from '../api/use-validate-email';

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

const FormSchema = z.object({
  email: z.string().min(6, {
    message: 'Email must have more than 6 characters'
  })
});

interface ValidateEmailFormProps {
  onSubmit: (email: string) => void;
}

const ValidateEmailForm: React.FC<ValidateEmailFormProps> = ({ onSubmit }) => {
  const { validateEmail, isLoading, error } = useValidateEmail();

  const form = useForm<z.infer<typeof FormSchema>>({
    resolver: zodResolver(FormSchema),
    defaultValues: {
      email: ''
    }
  });

  function handleSubmit(data: z.infer<typeof FormSchema>) {
    validateEmail(data);
    if (!error) {
      onSubmit(data.email);
    }
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
                <FormMessage>{error || form.formState.errors.email?.message}</FormMessage>
              </FormItem>
            )}
          />
          <Button className='mt-0' type='submit' disabled={isLoading}>
            {isLoading ? 'Sending...' : 'Send email'}
          </Button>
        </form>
      </Form>
    </div>
  );
};

export default ValidateEmailForm;
