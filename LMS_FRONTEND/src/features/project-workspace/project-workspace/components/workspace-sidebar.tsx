import { FaPhone, FaRProject } from 'react-icons/fa';
import { RiLockPasswordLine } from 'react-icons/ri';

import Sidebar from '@/components/shared/side-bar';
import { SidebarItem } from '@/types/ui';

const sidebarItems: SidebarItem[] = [
  {
    title: 'Project',
    href: '/project',
    icon: <FaRProject />
  },
  {
    title: 'List all Tasks',
    href: '/project/tasks',
    icon: <RiLockPasswordLine />
  },
  {
    title: 'Change Phone Number',
    href: '/profile/phone-number',
    icon: <FaPhone />
  }
];

export const WorkspaceSidebar = () => {
  return <Sidebar sidebarItems={sidebarItems} />;
};
