import React, { useState } from 'react';
import { Link } from 'react-router-dom';

import CreateProjectDialog from '@/components/app/create-project-dialog';
import {
  Pagination,
  PaginationContent,
  PaginationItem,
  PaginationLink,
  PaginationNext,
  PaginationPrevious
} from '@/components/ui/pagination';
import { authStore } from '@/lib/auth-store';

import { useOngoingProjects } from '../api/get-ongoing-projects';

const OngoingProjects: React.FC = () => {
  const { accessData } = authStore.getState();
  const userId = accessData?.id;

  const [pageNumber, setPageNumber] = useState(1);
  const [pageSize] = useState(12); // Set your default page size

  const {
    data: projectsData,
    isLoading: isProjectsLoading,
    refetch
  } = useOngoingProjects({
    projectQueryParams: {
      userId: userId || '',
      PageNumber: pageNumber,
      PageSize: pageSize
    }
  });

  const projects = projectsData?.data;
  const pagination = projectsData?.pagination;

  const handlePageChange = (newPageNumber: number) => {
    setPageNumber(newPageNumber);
    refetch();
  };

  if (isProjectsLoading) {
    return <div className='flex h-screen items-center justify-center'>Loading projects...</div>;
  }

  if (!projects || projects.length === 0) {
    return (
      <div className='flex h-screen items-center justify-center'>No ongoing projects found.</div>
    );
  }

  return (
    <div className='container mx-auto p-8'>
      <h1 className='mb-8 text-center text-3xl font-bold'>Your Projects</h1>
      <div className='mb-4 flex justify-center'>
        {userId && <CreateProjectDialog userId={userId} onSuccess={refetch} />}
      </div>
      <div className='grid grid-cols-1 gap-6 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4'>
        {projects.map((project) => (
          <div
            key={project.id}
            className='rounded-lg border bg-white p-6 shadow-md transition-shadow duration-300 hover:shadow-lg'
          >
            <Link
              to={`/project/workspace/${project.id}`}
              className='mb-2 text-xl font-bold text-blue-600'
            >
              {project.name}
            </Link>
            <p className='mb-4 text-gray-700'>{project.description}</p>
            <p className='mb-4 text-sm text-blue-600'>Task Undone: {project.taskUndone}</p>
          </div>
        ))}
      </div>
      {pagination && (
        <div className='mt-8 flex justify-center'>
          <Pagination>
            <PaginationContent>
              <PaginationItem>
                <PaginationPrevious
                  href='#'
                  onClick={(e) => {
                    e.preventDefault();
                    handlePageChange(Math.max(1, pageNumber - 1));
                  }}
                />
              </PaginationItem>
              {Array.from({ length: pagination.totalPages }, (_, index) => (
                <PaginationItem key={index}>
                  <PaginationLink
                    href='#'
                    isActive={index + 1 === pageNumber}
                    onClick={(e) => {
                      e.preventDefault();
                      handlePageChange(index + 1);
                    }}
                  >
                    {index + 1}
                  </PaginationLink>
                </PaginationItem>
              ))}
              <PaginationItem>
                <PaginationNext
                  href='#'
                  onClick={(e) => {
                    e.preventDefault();
                    handlePageChange(pagination.CurrentPage + 1);
                  }}
                />
              </PaginationItem>
            </PaginationContent>
          </Pagination>
        </div>
      )}
    </div>
  );
};

export default OngoingProjects;
