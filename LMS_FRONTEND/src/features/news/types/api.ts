import { Entity, QueryParams } from '@/types/api';

export type NewsQueryParams = {
  MinCreatedDate?: Date;
  MaxCreatedDate?: Date;
} & QueryParams;

export type News = Entity<{
  content: string;
  title: string;
  createdBy: string;
}>;
