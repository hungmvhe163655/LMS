import { useState } from 'react';
import { FaArrowLeft, FaArrowRight } from 'react-icons/fa';
import { Sidebar as RootSidebar, Menu, MenuItem } from 'react-pro-sidebar';
import { NavLink } from 'react-router-dom';

import { SidebarItem } from '@/types/ui';

import { Button } from '../ui/button';

interface SidebarProps {
  sidebarItems: SidebarItem[];
}

const Sidebar: React.FC<SidebarProps> = ({ sidebarItems }) => {
  const [isCollapsed, setIsCollapsed] = useState(false);

  return (
    <nav className='relative'>
      <Button
        onClick={() => setIsCollapsed(!isCollapsed)}
        className='absolute bottom-0 right-0 bg-gray-800 mb-3'
      >
        {isCollapsed ? <FaArrowRight /> : <FaArrowLeft />}
      </Button>
      <RootSidebar collapsed={isCollapsed}>
        <Menu
          menuItemStyles={{
            button: {
              [`&.active`]: {
                backgroundColor: '#13395e',
                color: '#b6c8d9'
              }
            }
          }}
        >
          {sidebarItems.map((item) => (
            <MenuItem icon={item.icon} key={item.href} component={<NavLink end to={item.href} />}>
              {item.title}
            </MenuItem>
          ))}
        </Menu>
      </RootSidebar>
    </nav>
  );
};

export default Sidebar;
