export type BaseEntity = {
  id: string;
  createdDate: Date;
};

export type Entity<T> = {
  [K in keyof T]: T[K];
} & BaseEntity;

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
  roles: ('Supervisor' | 'Student' | 'LabDirector')[];
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
  PageNumber?: number;
  PageSize?: number;
};

export type Token = {
  accessToken: string;
  refreshToken: string;
};

export type AuthResponse = {
  token: Token;
  user: User;
};
