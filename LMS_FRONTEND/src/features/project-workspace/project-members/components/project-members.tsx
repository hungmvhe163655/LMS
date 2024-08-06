import React from 'react';
import { FaUser } from 'react-icons/fa';
import { useParams } from 'react-router-dom';

import { Button } from '@/components/ui/button';
import { Table, TableRow, TableCell, TableHead, TableBody } from '@/components/ui/table'; // Assume these components exist

import { useProjectMembers, ProjectMember } from '../api/get-project-members';

const ProjectMembers: React.FC = () => {
  const { projectId } = useParams<{ projectId: string }>();

  const { data: members, isLoading, isError } = useProjectMembers({ projectId });

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error loading members</div>;
  }

  return (
    <div className='container mx-auto p-6'>
      <h1 className='mb-6 text-2xl font-bold'>Member Management</h1>
      <div className='mb-4 flex justify-between'>
        <p className='text-lg'>Supervisor: Le Phuong Chi</p>
        <p className='text-lg'>Team Size: {members?.length}/5</p>
      </div>
      <Table className='min-w-full'>
        <TableHead>
          <TableRow>
            <TableCell>Name</TableCell>
            <TableCell>Joined Date</TableCell>
            <TableCell></TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {members?.map((member: ProjectMember) => (
            <TableRow key={member.userId}>
              <TableCell>
                <div className='flex items-center'>
                  <FaUser className='mr-2' />
                  {member.fullName}
                  {member.isLeader && (
                    <span className='ml-2 rounded bg-green-500 px-2 py-1 text-white'>Leader</span>
                  )}
                </div>
              </TableCell>
              <TableCell>{new Date(member.joinDate).toLocaleDateString()}</TableCell>
              <TableCell>
                <Button variant='destructive' size='sm'>
                  Remove
                </Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </div>
  );
};

export default ProjectMembers;
