import { zodResolver } from '@hookform/resolvers/zod';
import React from 'react';
import { useForm } from 'react-hook-form';
import { z } from 'zod';

import { Button } from '@/components/ui/button';
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

const projectSchema = z.object({
  name: z.string().nonempty('Name is required'),
  description: z.string().max(500, 'Description must be less than 500 characters'),
  maxMember: z.number().positive('Max member must be greater than 0')
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
      maxMember: 1
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
        isRecruiting: true, // Assuming a default value
        projectTypeId: 1 // Assuming a default project type ID
      });

      handleDialogOpenChange(false);
      onSuccess();
    } catch (error) {
      console.error('Error creating project:', error);
    }
  };

  return (
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
            <DialogFooter>
              <Button type='submit'>Create</Button>
            </DialogFooter>
          </form>
        </Form>
      </DialogContent>
    </Dialog>
  );
};

export default CreateProjectDialog;
