import { FaPhone, FaUser } from 'react-icons/fa';
import { RiLockPasswordLine } from 'react-icons/ri';

import Sidebar from '@/components/shared/side-bar';
import { SidebarItem } from '@/types/ui';

const sidebarItems: SidebarItem[] = [
  {
    title: 'Overall',
    href: '/profile',
    icon: <FaUser />
  },
  {
    title: 'Change Password',
    href: '/profile/password',
    icon: <RiLockPasswordLine />
  },
  {
    title: 'Change Phone Number',
    href: '/profile/phone-number',
    icon: <FaPhone />
  }
];

export const ProfileSidebar = () => {
  return <Sidebar sidebarItems={sidebarItems} />;
};
