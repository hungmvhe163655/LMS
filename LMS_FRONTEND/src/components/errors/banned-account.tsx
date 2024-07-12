import { Button } from '../ui/button';

export function BannedAccount() {
  return (
    <div className='mx-auto flex flex-col items-center justify-center text-red-500'>
      <h2 className='text-lg font-semibold'>Your Account Is Banned :( </h2>
      <Button className='mt-4' onClick={() => window.location.assign(window.location.origin)}>
        Return to Login
      </Button>
    </div>
  );
}
