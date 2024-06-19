import { SidebarNav } from '@/features/profile/components/sidebar';
import { SidebarNavItem } from '@/features/profile/types/type';

type LayoutProps = {
  children: React.ReactNode;
};

const sidebarItems: SidebarNavItem[] = [
  {
    title: 'Overall',
    href: '/profile/overall'
  },
  {
    title: 'Change Password',
    href: '/profile/password'
  },
  {
    title: 'Change Email',
    href: '/profile/email'
  },
  {
    title: 'Change Phone Number',
    href: '/profile/phone-number'
  },
  {
    title: 'Two-Factor Authentication',
    href: '/profile/two-factor'
  }
];

export function Layout({ children }: LayoutProps) {
  return (
    <div className='flex min-h-screen bg-gray-50'>
      <div className='w-64 bg-white p-4 shadow'>
        <SidebarNav items={sidebarItems} />
      </div>
      <div className='flex flex-1 flex-col py-2 sm:px-2 lg:px-4'>
        <div className='mt-8 sm:mx-auto sm:w-full sm:max-w-md'>
          <div className='bg-white px-4 py-8 shadow sm:rounded-lg sm:px-10'>{children}</div>
        </div>
      </div>
    </div>
  );
}
