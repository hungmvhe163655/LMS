import { zodResolver } from '@hookform/resolvers/zod';
import React from 'react';
import { useForm } from 'react-hook-form';
import { z } from 'zod';

import { Button } from '@/components/ui/button';
import { Checkbox } from '@/components/ui/checkbox'; // Import the Checkbox component
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogFooter,
  DialogTrigger
} from '@/components/ui/dialog';
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage
} from '@/components/ui/form';
import { Input } from '@/components/ui/input';
import { createProject } from '@/features/project-workspace/ongoing-projects/api/create-project';
import { authStore } from '@/lib/auth-store';

const { accessData } = authStore.getState();
const userRoles = accessData?.roles || [];

const projectSchema = z.object({
  name: z.string().nonempty('Name is required'),
  description: z.string().max(500, 'Description must be less than 500 characters'),
  maxMember: z
    .string()
    .regex(/^\d+$/, 'Max member must be a number')
    .transform((val) => Number(val))
    .refine((val) => val > 0, 'Max member must be greater than 0'),
  isRecruiting: z.boolean() // Add validation for the isRecruiting field
});

type ProjectFormData = z.infer<typeof projectSchema>;

interface CreateProjectDialogProps {
  userId: string;
  onSuccess: () => void;
}

const CreateProjectDialog: React.FC<CreateProjectDialogProps> = ({ userId, onSuccess }) => {
  const [isDialogOpen, setIsDialogOpen] = React.useState(false);

  const form = useForm<ProjectFormData>({
    resolver: zodResolver(projectSchema),
    defaultValues: {
      name: '',
      description: '',
      maxMember: 1,
      isRecruiting: true // Set default value for isRecruiting
    }
  });

  const handleDialogOpenChange = (isOpen: boolean) => {
    setIsDialogOpen(isOpen);
  };

  const handleFormSubmit = async (data: ProjectFormData) => {
    try {
      await createProject({
        ...data,
        createdBy: userId,
        createdDate: new Date().toISOString(),
        projectStatus: 'Active', // Assuming a default status
        projectTypeId: 1 // Assuming a default project type ID
      });

      handleDialogOpenChange(false);
      onSuccess();
    } catch (error) {
      console.error('Error creating project:', error);
    }
  };

  return (
    <div>
      {!userRoles.includes('STUDENT') && (
        <Dialog open={isDialogOpen} onOpenChange={handleDialogOpenChange}>
          <DialogTrigger asChild>
            <Button onClick={() => handleDialogOpenChange(true)}>Create New Project</Button>
          </DialogTrigger>
          <DialogContent>
            <DialogHeader>
              <DialogTitle>Create New Project</DialogTitle>
            </DialogHeader>
            <Form {...form}>
              <form onSubmit={form.handleSubmit(handleFormSubmit)} className='space-y-4'>
                <FormField
                  control={form.control}
                  name='name'
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel>Name</FormLabel>
                      <FormControl>
                        <Input {...field} placeholder='Project name' />
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
                <FormField
                  control={form.control}
                  name='description'
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel>Description</FormLabel>
                      <FormControl>
                        <Input {...field} placeholder='Project description' />
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
                <FormField
                  control={form.control}
                  name='maxMember'
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel>Max Member</FormLabel>
                      <FormControl>
                        <Input {...field} type='number' placeholder='Max member' />
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
                <FormField
                  control={form.control}
                  name='isRecruiting'
                  render={({ field }) => (
                    <FormItem className='flex items-center space-x-2'>
                      <FormControl>
                        <Checkbox
                          id='isRecruiting'
                          checked={field.value}
                          onCheckedChange={field.onChange}
                        />
                      </FormControl>
                      <FormLabel htmlFor='isRecruiting' className='text-sm font-medium'>
                        Is Recruiting
                      </FormLabel>
                    </FormItem>
                  )}
                />
                <DialogFooter>
                  <Button type='submit'>Create</Button>
                </DialogFooter>
              </form>
            </Form>
          </DialogContent>
        </Dialog>
      )}
    </div>
  );
};

export default CreateProjectDialog;