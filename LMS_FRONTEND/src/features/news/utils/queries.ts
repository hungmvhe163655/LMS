import { NewsQueryParams } from '../types/api';

export const newsKeys = {
  all: ['news'] as const,

  lists: () => [...newsKeys.all, 'list'] as const,
  list: (params?: NewsQueryParams) => [...newsKeys.lists(), params] as const,

  details: () => [...newsKeys.all, 'detail'] as const,
  detail: (id: string) => [...newsKeys.details(), id] as const
};
