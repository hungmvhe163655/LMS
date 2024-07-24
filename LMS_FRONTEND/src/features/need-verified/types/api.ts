import { QueryParams } from '@/types/api';
import { ROLES } from '@/types/constant';

export type NeedVerfiedAccount = {
  id: string;
  fullName: string;
};

export type VerifiedAccountsQueryParams = {
  SearchContent?: string | null;
  Role?: typeof ROLES.STUDENT | typeof ROLES.SUPERVISOR;
} & QueryParams;

export type VerifyAccount = {
  userId: string[];
};
