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
import { RadioGroup, RadioGroupItem } from '@/components/ui/radio-group';
import { User } from '@/types/api';

import { StudentDetail } from '../types/api';

const formSchema = z.object({
  fullName: z.string().min(3),
  gender: z.enum(['male', 'female']),
  rollNumber: z
    .string()
    .min(8)
    .regex(/^[A-Za-z]{2}\d{6}$/, {
      message: 'Invalid Roll Number'
    })
    .optional()
    .or(z.literal('')),
  major: z.string().min(6).optional().or(z.literal('')),
  specilized: z.string().min(6).optional().or(z.literal(''))
});

export function EditProfileForm(user: User, studetDetail: StudentDetail | null) {
  const isStudent = user.roles.includes('Student');

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      fullName: user.fullName,
      rollNumber: studetDetail?.rollNumber,
      major: studetDetail?.major,
      specilized: studetDetail?.specialized,
      gender: user.gender.toLowerCase() === 'male' ? 'male' : 'female'
    }
  });

  function onSubmit(data: z.infer<typeof formSchema>) {
    console.log(data);
  }

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)} className='space-y-3 p-3'>
        {/* Full Name */}
        <FormField
          control={form.control}
          name='fullName'
          render={({ field }) => (
            <FormItem>
              <FormLabel>Full Name</FormLabel>
              <FormControl>
                <Input type='text' {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Gender */}
        <FormField
          control={form.control}
          name='gender'
          render={({ field }) => (
            <FormItem>
              <FormLabel>Gender</FormLabel>
              <FormControl className='flex items-center space-x-6'>
                <RadioGroup onValueChange={field.onChange} defaultValue={field.value}>
                  <FormItem className='flex space-x-3 space-y-0'>
                    <FormControl>
                      <RadioGroupItem value='male' />
                    </FormControl>
                    <FormLabel className='font-normal'>Male</FormLabel>
                  </FormItem>
                  <FormItem className='flex space-x-3 space-y-0'>
                    <FormControl>
                      <RadioGroupItem value='female' />
                    </FormControl>
                    <FormLabel className='font-normal'>Female</FormLabel>
                  </FormItem>
                </RadioGroup>
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Roll Number */}
        {isStudent && (
          <FormField
            control={form.control}
            name='rollNumber'
            render={({ field }) => (
              <FormItem>
                <FormLabel>Roll Number</FormLabel>
                <FormControl>
                  <Input type='text' {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
        )}

        {/* Major */}
        {isStudent && (
          <FormField
            control={form.control}
            name='major'
            render={({ field }) => (
              <FormItem>
                <FormLabel>Major</FormLabel>
                <FormControl>
                  <Input type='text' {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
        )}

        {isStudent && (
          <FormField
            control={form.control}
            name='specilized'
            render={({ field }) => (
              <FormItem>
                <FormLabel>Specilized</FormLabel>
                <FormControl>
                  <Input type='text' {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
        )}

        <div className='flex justify-end'>
          <Button type='submit'>Confirm</Button>
        </div>
      </form>
    </Form>
  );
}
