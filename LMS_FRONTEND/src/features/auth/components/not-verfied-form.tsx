import { zodResolver } from '@hookform/resolvers/zod';
import { useState } from 'react';
import { useForm } from 'react-hook-form';
import { useNavigate } from 'react-router-dom';
import { z } from 'zod';

import { Link } from '@/components/app/link';
import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardFooter, CardHeader } from '@/components/ui/card';
import { Form, FormField, FormItem, FormLabel, FormMessage } from '@/components/ui/form';
import { toast } from '@/components/ui/use-toast';

import { useChangeSupervisor } from '../api/change-supervisor';

import SupervisorSelect from './supervisor-select';

// FormSchema and Validation
const FormSchema = z.object({
  supervisorId: z.string()
});

interface NotVerifiedFormProps {
  accountId: string;
  verifierId: string;
}

export const NotVerifiedForm = ({ accountId, verifierId }: NotVerifiedFormProps) => {
  const { mutate: changeSupervisor, isPending } = useChangeSupervisor();
  const navigate = useNavigate();
  const [isChange, setIsChange] = useState<boolean>(false);

  const form = useForm<z.infer<typeof FormSchema>>({
    resolver: zodResolver(FormSchema),
    defaultValues: {
      supervisorId: verifierId
    }
  });

  function onSubmit(data: z.infer<typeof FormSchema>) {
    changeSupervisor(
      { verifierId: data.supervisorId, id: accountId },
      {
        onSuccess: () => {
          toast({
            variant: 'success',
            description: 'Change Successfully!'
          });
          navigate('/');
        }
      }
    );
  }

  return (
    <Card>
      <CardHeader className='space-y-6'>
        <CardDescription className='font-bold italic text-red-500'>
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
