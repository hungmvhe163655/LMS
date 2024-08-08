import { ResourceQueryParams } from '../types/api';

export const resourceKeys = {
  all: ['resources'] as const,

  contents: () => [...resourceKeys.all, 'content'] as const,
  content: (id: string) => [...resourceKeys.contents(), id] as const,

  lists: (id: string) => [...resourceKeys.content(id), 'list'] as const,
  list: (id: string, params?: ResourceQueryParams) => [...resourceKeys.lists(id), params] as const,

  roots: () => [...resourceKeys.all, 'root'] as const,
  root: (projectId: string) => [...resourceKeys.roots(), projectId] as const,

  files: () => [...resourceKeys.all, 'file'] as const,
  file: (fileId: string) => [...resourceKeys.files(), fileId] as const
};
