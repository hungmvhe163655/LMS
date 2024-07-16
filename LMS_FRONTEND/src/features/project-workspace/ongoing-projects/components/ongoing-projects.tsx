import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

interface Project {
  id: string;
  Name: string;
  Description: string;
  CreatedDate: Date;
  ProjectStatusId: number;
  MaxMember: number;
  IsRecruiting: boolean;
  ProjectTypeId: number;
}

const OngoingProjects: React.FC = () => {
  const [projects, setProjects] = useState<Project[]>([]);

  useEffect(() => {
    fetchProjects();
  }, []);

  const fetchProjects = async () => {
    // Simulate API call
    const response: Project[] = [
      {
        id: '1',
        Name: 'Lab Management System',
        Description: 'A system for managing the SAP Laboratory of FPT University',
        CreatedDate: new Date(),
        ProjectStatusId: 1,
        MaxMember: 10,
        IsRecruiting: true,
        ProjectTypeId: 1
      },
      {
        id: '2',
        Name: 'Blockchain Pokemon',
        Description: 'Sample description text ...',
        CreatedDate: new Date(),
        ProjectStatusId: 1,
        MaxMember: 10,
        IsRecruiting: true,
        ProjectTypeId: 1
      },
      {
        id: '3',
        Name: 'Shopping App',
        Description: 'Sample description text ...',
        CreatedDate: new Date(),
        ProjectStatusId: 1,
        MaxMember: 10,
        IsRecruiting: true,
        ProjectTypeId: 1
      },
      {
        id: '4',
        Name: 'Grab 3.0',
        Description: 'Sample description text ...',
        CreatedDate: new Date(),
        ProjectStatusId: 1,
        MaxMember: 10,
        IsRecruiting: true,
        ProjectTypeId: 1
      }
    ];

    setProjects(response);
  };

  return (
    <div className='container mx-auto p-4'>
      <h1 className='mb-4 text-2xl font-bold'>Your Projects</h1>
      <div className='flex gap-4 overflow-auto'>
        {projects.map((project) => (
          <div key={project.id} className='w-64 rounded-lg border bg-gray-100 p-4 shadow-sm'>
            <h2 className='text-xl font-semibold text-blue-600'>{project.Name}</h2>
            <p className='mb-2 text-gray-700'>{project.Description}</p>
            <p className='text-sm text-blue-600'>Task undone: 5</p>
            <Link
              className='mt-2 flex items-center text-sm text-blue-600'
              to={`/project/workspace/${project.id}`}
            >
              Go to project workspace <span className='ml-1'>→</span>
            </Link>
          </div>
        ))}
      </div>
    </div>
  );
};

export default OngoingProjects;
