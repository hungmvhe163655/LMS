import { FaCog, FaRProject } from 'react-icons/fa';
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
    title: 'Project Settings',
    href: '/project/settings',
    icon: <FaCog />
  }
];

export const WorkspaceSidebar = () => {
  return <Sidebar sidebarItems={sidebarItems} />;
};
