import { GiTeacher } from 'react-icons/gi';
import { PiStudent } from 'react-icons/pi';

import { ROLES } from '@/types/constant';

import { Role } from '../utils/schema';

interface SelectRoleProps {
  onSelectRole: (role: Role) => void;
}

function ChooseRoleRegister({ onSelectRole }: SelectRoleProps) {
  return (
    <div className='flex justify-center space-x-8'>
      <button
        className='flex flex-col items-center rounded-md bg-slate-200 p-4 hover:bg-slate-300'
        onClick={() => onSelectRole(ROLES.STUDENT)}
      >
        <PiStudent className='size-32' />
        <p className='text-center font-bold'>Student</p>
      </button>

      <button
        className='flex flex-col items-center rounded-md bg-slate-200 p-4 hover:bg-slate-300'
        onClick={() => onSelectRole(ROLES.SUPERVISOR)}
      >
        <GiTeacher className='size-32' />
        <p className='text-center font-bold'>Supervisor</p>
      </button>
    </div>
  );
}

export default ChooseRoleRegister;
