export type BaseEntity = {
  id: string;
  createdDate: Date;
};

export type Entity<T> = {
  [K in keyof T]: T[K];
} & BaseEntity;

export type User = Entity<{
  fullname: string;
  email: string;
  gender: boolean;
  verifiedBy: string | null;
  isDeleted: boolean;
  isBanned: boolean;
  roles: ('SUPERVISOR' | 'STUDENT' | 'LAB_DIRECTOR')[];
}>;

export type Pagination = {
  CurrentPage: number;
  TotalPages: number;
  PageSize: number;
  TotalCount: number;
  HasPrevious: boolean;
  HasNext: boolean;
};

export type PaginationParameters = {
  PageNumber?: number;
  PageSize?: number;
};

export type News = Entity<{
  content: string;
  title: string;
  createdBy: string;
}>;

export type AuthResponse = {
  accessToken: string;
  refreshToken: string;
  user: User;
};
