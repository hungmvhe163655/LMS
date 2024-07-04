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
  verifiedBy: string | null;
  roles: ('Supervisor' | 'Student' | 'Lab Director')[];
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

export type AuthResponse = {
  token: {
    accessToken: string;
    refreshToken: string;
  };
  user: User;
};
