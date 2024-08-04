import { ROLES } from '@/types/constant';

export type BaseEntity = {
  id: string;
  createdDate: Date;
};

export type Entity<T> = {
  [K in keyof T]: T[K];
} & BaseEntity;

export type Roles = (typeof ROLES)[keyof typeof ROLES][];

export type User = Entity<{
  email: string;
  phoneNumber: string;
  userName: string;
  fullName: string;
  gender: string;
  isDeleted: boolean;
  isBanned: boolean;
  isVerified: boolean;
  verifiedBy: string | null;
  roles: Roles;
  rollNumber?: string;
  major?: string;
  specialized?: string;
}>;

export type UserLogin = Entity<{
  roles: Roles;
}>;

export type Pagination = {
  CurrentPage: number;
  TotalPages: number;
  PageSize: number;
  TotalCount: number;
  HasPrevious: boolean;
  HasNext: boolean;
};

export type QueryParams = {
  PageNumber: number;
  PageSize: number;
  OrderBy: string | null;
};

export type Token = {
  accessToken: string;
  refreshToken: string;
};

export type AuthResponse = {
  token: Token;
  user: User;
};
