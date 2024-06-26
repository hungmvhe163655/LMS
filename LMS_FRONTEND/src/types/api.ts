export type BaseEntity = {
  id: string;
  createdDate: number;
};

export type Entity<T> = {
  [K in keyof T]: T[K];
} & BaseEntity;

export type User = Entity<{
  fullname: string;
  email: string;
  gender: boolean;
  verifiedBy: string;
  isDeleted: boolean;
  isBanned: boolean;
  role: 'SUPERVISOR' | 'STUDENT' | 'LAB_DIRECTOR';
}>;

export type AuthResponse = {
  accessToken: string;
  refreshToken: string;
  user: User;
};
