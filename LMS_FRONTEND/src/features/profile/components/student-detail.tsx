import { useStudentDetail } from '../api/get-student-profile';

interface StudentDetailProps {
  id: string;
}
export function StudentDetail({ id }: StudentDetailProps) {
  const { isLoading, data } = useStudentDetail({
    studentProfileQueryParameter: { id }
  });

  if (isLoading) {
    return <div>Loading...</div>;
  }

  return (
    <div className='flex space-y-2'>
      <div className='flex flex-col space-y-0 lg:space-y-3'>
        <span className='text-gray-600'>
          <span className='font-bold'> Roll Number:</span> {data?.data.rollNumber}
        </span>
        <span className='text-gray-600'>
          <span className='font-bold'> Major:</span> {data?.data.major}
        </span>
        <span className='text-gray-600'>
          <span className='font-bold'>Specialized:</span> {data?.data.specialized}
        </span>
      </div>
    </div>
  );
}
