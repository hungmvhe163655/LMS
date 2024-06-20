export interface SidebarNavItem {
  title: string;
  href: string;
  disabled?: boolean;
  external?: boolean;
}

export interface SidebarNavProps {
  items: SidebarNavItem[];
}
