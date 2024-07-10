import { Button } from '@/components/ui/button';

const ActiveProject = () => {
  const projects = ['Project 1', 'Project 2'];

  return (
    <div className='rounded-md bg-blue-100 p-4 shadow-md'>
      <h2 className='mb-4 text-xl font-semibold'>ACTIVE PROJECT</h2>
      {projects.map((project, index) => (
        <Button key={index} className='mt-2 w-full rounded-lg bg-blue-500 px-4 py-2 text-white'>
          {project}
        </Button>
      ))}
      <Button className='mt-2 w-full rounded-lg bg-blue-500 px-4 py-2 text-white'>
        View your projects
      </Button>
    </div>
  );
};

export default ActiveProject;
