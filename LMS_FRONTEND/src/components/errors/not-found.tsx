import { Link } from '../app/link';

type LayoutProps = {
  title: string;
  message: string;
};

export function NotFoundFallback({ title, message }: LayoutProps) {
  return (
    <div className='m-auto flex h-dvh items-center justify-center font-semibold'>
      <div className='text-center'>
        <h1 className='text-4xl text-red-500'>{title}</h1>
        <p className='my-2'>{message}</p>
        <Link to='/' replace>
          Go to Home
        </Link>
      </div>
    </div>
  );
}
