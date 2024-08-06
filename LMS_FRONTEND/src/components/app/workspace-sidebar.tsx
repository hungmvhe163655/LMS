import React from 'react';
import { FaCog, FaList, FaRProject, FaUser } from 'react-icons/fa';
import { useParams } from 'react-router-dom';

import Sidebar from '@/components/shared/side-bar';
import { SidebarItem } from '@/types/ui';

const WorkspaceSidebar: React.FC = () => {
  const { projectId } = useParams<{ projectId: string }>();

  const sidebarItems: SidebarItem[] = [
    {
      title: 'Project',
      href: '/project',
      icon: <FaRProject />
    },
    {
      title: 'List all Tasks',
      href: '/project/tasks',
      icon: <FaList />
    }
  ];

  if (projectId) {
    sidebarItems.push({
      title: 'Project Settings',
      href: `/project/settings/${projectId}`,
      icon: <FaCog />
    });
    sidebarItems.push({
      title: 'Members',
      href: `/project/members/${projectId}`,
      icon: <FaUser />
    });
  }

  return <Sidebar sidebarItems={sidebarItems} />;
};

export default WorkspaceSidebar;
