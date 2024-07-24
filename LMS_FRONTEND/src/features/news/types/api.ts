import { z } from 'zod';

import { Entity, QueryParams } from '@/types/api';

export type NewsQueryParams = {
  SearchTerm?: string | null;
} & QueryParams;

export type News = Entity<{
  content: string;
  title: string;
  createdBy: string;
}>;

export const CONTENT_LIMIT = 1000;

export const createNewsInputSchema = z.object({
  title: z.string().min(1).trim(),
  content: z.string().min(1).max(CONTENT_LIMIT).trim()
});
export type CreateNewsInputSchema = z.infer<typeof createNewsInputSchema>;

export const updateNewsInputSchema = z.object({
  title: z.string().min(1).trim(),
  content: z.string().min(1).max(CONTENT_LIMIT).trim()
});
export type UpdateNewsInputSchema = z.infer<typeof updateNewsInputSchema>;

export const createNewsAPISchema = z
  .object({
    createdBy: z.string().min(1)
  })
  .and(createNewsInputSchema);
export type CreateNewsAPISchema = z.infer<typeof createNewsAPISchema>;
