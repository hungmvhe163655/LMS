import { Entity, QueryParams } from '@/types/api';

export type NewsQueryParams = {
  SearchTerm?: string | null;
} & QueryParams;

export type News = Entity<{
  content: string;
  title: string;
  createdBy: string;
}>;
