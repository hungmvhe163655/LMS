import { GiTeacher } from 'react-icons/gi';
import { PiStudent } from 'react-icons/pi';

import { Link } from '@/components/ui/link';

function ChooseRoleRegister() {
  return (
    <div className='flex justify-center space-x-8'>
      <Link
        to='/auth/roll-number'
        className='rounded-lg bg-slate-200 text-black hover:bg-slate-300 hover:text-black'
      >
        <div className='rounded-md p-4'>
          <PiStudent className='size-32' />
          <p className='text-center font-bold'>Student</p>
        </div>
      </Link>

      <Link
        to='/auth/register/choose-role/supervisor'
        className='rounded-lg bg-slate-200 text-black hover:bg-slate-300 hover:text-black'
      >
        <div className='p-4'>
          <GiTeacher className='size-32' />
          <p className='text-center font-bold'>Supervisor</p>
        </div>
      </Link>
    </div>
  );
}

export default ChooseRoleRegister;
