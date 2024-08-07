import { ResourceQueryParams } from '../types/api';

export const resourceKeys = {
  all: ['resources'] as const,

  contents: () => [...resourceKeys.all, 'content'] as const,
  content: (id: string) => [...resourceKeys.contents(), id] as const,

  list: (id: string) => [...resourceKeys.content(id), 'list'] as const,
  lists: (id: string, params?: ResourceQueryParams) => [...resourceKeys.list(id), params] as const,

  roots: () => [...resourceKeys.all, 'root'] as const,
  root: (projectId: string) => [...resourceKeys.roots(), projectId] as const
};
