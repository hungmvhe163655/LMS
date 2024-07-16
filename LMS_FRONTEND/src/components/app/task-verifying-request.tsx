// eslint-disable-next-line import/order
import { Link } from 'react-router-dom';
import { Button } from '@/components/ui/button';

const TaskVerifyingRequest = () => {
  const tasks = [
    'Implement code for project listing',
    'Fix supervisor register function',
    'Finish report 4'
  ];

  return (
    <div className='rounded-md bg-blue-100 p-4 shadow-md'>
      <h2 className='mb-4 text-xl font-semibold'>Task verify requests</h2>
      {tasks.map((task, index) => (
        <div key={index} className='mb-2 flex items-center'>
          <Button className=' mr-2 mt-2 w-full grow rounded-lg bg-blue-500 px-4 py-2 text-white'>
            {task}
          </Button>
          <Button className='shrink bg-blue-500'>➔</Button>
        </div>
      ))}
      <Link className='mt-2 flex items-center text-sm text-blue-600' to={`/project/tasks`}>
        View all tasks <span className='ml-1'>→</span>
      </Link>
    </div>
  );
};

export default TaskVerifyingRequest;
