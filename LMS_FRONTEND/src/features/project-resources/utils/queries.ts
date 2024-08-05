import { ResourceQueryParams } from '../types/api';

export const folderKeys = {
  all: ['folders'] as const,
  contents: () => [...folderKeys.all, 'content'] as const,
  content: (id: string) => [...folderKeys.contents(), id] as const,

  list: (id: string) => [...folderKeys.content(id), 'list'] as const,
  lists: (id: string, params?: ResourceQueryParams) => [...folderKeys.list(id), params] as const
};

export const fileKeys = {
  all: ['files'] as const,
  contents: () => [...fileKeys.all, 'content'] as const,
  content: (id: string) => [...fileKeys.contents(), id] as const,

  list: (id: string) => [...fileKeys.content(id), 'list'] as const,
  lists: (id: string, params?: ResourceQueryParams, ...remaining: any) =>
    [...fileKeys.list(id), params, ...remaining] as const
};
