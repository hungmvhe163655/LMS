import React from 'react';
import { z } from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';
import { Button } from '@/components/ui/button';
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle
} from '@/components/ui/card';

import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage
} from '@/components/ui/form';
import { Input } from '@/components/ui/input';
import { useForm } from 'react-hook-form';
import { useNavigate } from 'react-router-dom'; // Import useNavigate from react-router-dom

const FormSchema = z.object({
  studentCode: z.string().length(8, 'Student Code must have 8 characters') // Adjusted length to 8 as per placeholder example
});

const ValidateRollNumber: React.FC = () => {
  const navigate = useNavigate(); // Initialize useNavigate
  const form = useForm<z.infer<typeof FormSchema>>({
    resolver: zodResolver(FormSchema),
    defaultValues: {
      studentCode: ''
    }
  });

  function onSubmit(data: z.infer<typeof FormSchema>) {
    console.log(data);
    // Navigate to StudentRegister with student code as a query parameter
    navigate(`/register/student?studentCode=${data.studentCode}`);
  }

  return (
    <div className='container'>
      <Card className='card'>
        <CardHeader>
          <CardTitle>Verify Student Roll Number</CardTitle>
          <CardDescription>Here we will verify your student roll number somehow.</CardDescription>
        </CardHeader>
        <CardContent>
          <Form {...form}>
            <form onSubmit={form.handleSubmit(onSubmit)} className='space-y-6'>
              <FormField
                control={form.control}
                name='studentCode'
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Student Roll Number</FormLabel>
                    <FormControl>
                      <Input placeholder='Example: HE123456' {...field} />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
              <Button type='submit' className='submit-button'>
                Next
              </Button>
            </form>
          </Form>
        </CardContent>
        <CardFooter></CardFooter>
      </Card>
    </div>
  );
};

export default ValidateRollNumber;
