import React, { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { useParams } from 'react-router-dom';

import { Button } from '@/components/ui/button';
import { Checkbox } from '@/components/ui/checkbox';
import { Input } from '@/components/ui/input';
import { Label } from '@/components/ui/label';
import {
  Select,
  SelectContent,
  SelectGroup,
  SelectItem,
  SelectLabel,
  SelectTrigger,
  SelectValue
} from '@/components/ui/select';
import { Textarea } from '@/components/ui/textarea';

import { useProjectById } from '../api/get-project-by-id';

interface ProjectSettingsForm {
  numberOfMembers: number;
  allowRequestsJoin: boolean;
  projectName: string;
  projectDescription: string;
  currentLeader: string;
}

const ProjectSettings: React.FC = () => {
  const { projectId } = useParams<{ projectId: string }>();

  const { register, handleSubmit, setValue, watch } = useForm<ProjectSettingsForm>({
    defaultValues: {
      numberOfMembers: 0,
      allowRequestsJoin: false,
      projectName: '',
      projectDescription: '',
      currentLeader: ''
    }
  });

  const { data: projectData, isLoading } = useProjectById({ projectId: projectId! });

  useEffect(() => {
    if (projectData) {
      setValue('projectName', projectData.name);
      setValue('projectDescription', projectData.description);
      // Assuming currentLeader and numberOfMembers come from projectData
      // setValue('currentLeader', projectData.currentLeader);
      // setValue('numberOfMembers', projectData.numberOfMembers);
    }
  }, [projectData, setValue]);

  const onSubmit = (data: ProjectSettingsForm) => {
    console.log(data);
  };

  if (isLoading) {
    return <div>Loading...</div>;
  }

  return (
    <div className='container mx-auto p-6'>
      <h1 className='mb-6 text-2xl font-bold'>Project Settings</h1>
      <form onSubmit={handleSubmit(onSubmit)} className='space-y-6'>
        <div className='flex items-center space-x-4'>
          <Label className='min-w-[200px]'>Number of Members:</Label>
          <span className='text-lg font-medium'>{watch('numberOfMembers')}</span>
        </div>
        <div className='flex items-center space-x-4'>
          <Label className='min-w-[200px]'>Allow Requests Join:</Label>
          <Checkbox {...register('allowRequestsJoin')} />
        </div>
        <div className='flex items-center space-x-4'>
          <Label className='min-w-[200px]'>Project Name:</Label>
          <Input {...register('projectName')} readOnly />
        </div>
        <div className='flex items-center space-x-4'>
          <Label className='min-w-[200px]'>Project Description:</Label>
          <Textarea {...register('projectDescription')} rows={4} className='flex-1' />
        </div>
        <div className='flex items-center space-x-4'>
          <Label className='min-w-[200px]'>Current Leader:</Label>
          <Select {...register('currentLeader')}>
            <SelectTrigger className='w-[180px]'>
              <SelectValue placeholder='Select a leader' />
            </SelectTrigger>
            <SelectContent>
              <SelectGroup>
                <SelectLabel>Leaders</SelectLabel>
                <SelectItem value='Mai Viet Hung'>Mai Viet Hung</SelectItem>
                <SelectItem value='John Doe'>John Doe</SelectItem>
                <SelectItem value='Jane Doe'>Jane Doe</SelectItem>
              </SelectGroup>
            </SelectContent>
          </Select>
        </div>
        <div className='flex justify-end'>
          <Button type='submit' className='rounded-md bg-green-500 px-6 py-2 text-white'>
            Save
          </Button>
        </div>
      </form>
    </div>
  );
};

export default ProjectSettings;
