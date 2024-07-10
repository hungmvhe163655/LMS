import { zodResolver } from '@hookform/resolvers/zod';
import { useState } from 'react';
import { useForm } from 'react-hook-form';
import { z } from 'zod';

import { Link } from '@/components/app/link';
import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardFooter, CardHeader } from '@/components/ui/card';
import { Form, FormField, FormItem, FormLabel, FormMessage } from '@/components/ui/form';

import { useChangeSupervisor } from '../api/change-supervisor';

import SupervisorSelect from './supervisor-select';

// FormSchema and Validation
const FormSchema = z.object({
  supervisorId: z.string()
});

export const NotVerifiedForm = () => {
  const { mutate: changeSupervisor, isPending } = useChangeSupervisor();
  const [isChange, setIsChange] = useState<boolean>(false);

  const form = useForm<z.infer<typeof FormSchema>>({
    resolver: zodResolver(FormSchema),
    defaultValues: {
      supervisorId: ''
    }
  });

  function onSubmit(data: z.infer<typeof FormSchema>) {
    changeSupervisor(data.supervisorId);
  }

  return (
    <Card>
      <CardHeader>
        <CardDescription className='font-bold italic text-red-700'>
          Your Account is Not Verified yet! Please Contact to The Supervisor to Approve.
        </CardDescription>
        {isChange || <Button onClick={() => setIsChange(true)}>Change Suppervisor?</Button>}
      </CardHeader>

      {isChange && (
        <CardContent className='py-0'>
          <Form {...form}>
            <form onSubmit={form.handleSubmit(onSubmit)} className='mb-4 space-y-4'>
              {/* Supervisor Input Field */}
              <FormField
                control={form.control}
                name='supervisorId'
                render={({ field }) => (
                  <FormItem className='flex flex-col'>
                    <FormLabel>Supervisor</FormLabel>
                    <SupervisorSelect form={form} field={field} name='supervisorId' />
                    <FormMessage />
                  </FormItem>
                )}
              />
              <Button type='submit' className='w-full' disabled={isPending}>
                {isPending ? 'Changing...' : 'Change'}
              </Button>
            </form>
          </Form>
        </CardContent>
      )}
      <CardFooter className='flex flex-col items-start space-y-1'>
        <div>
          Don&apos;t have an account? <Link to='/auth/register'>Register now!</Link>
        </div>
        <div>
          Don&apos;t remember your password?{' '}
          <Link to='/auth/forget-password'> Forget Password</Link>
        </div>
      </CardFooter>
    </Card>
  );
};

export default NotVerifiedForm;
