import { VerifiedAccountsQueryParams } from '../types/api';

export const VerifiedAccountKeys = {
  all: ['verfied-account'] as const,

  lists: () => [...VerifiedAccountKeys.all, 'list'] as const,
  list: (params?: VerifiedAccountsQueryParams) => [...VerifiedAccountKeys.lists(), params] as const
};
