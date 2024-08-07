import { z } from 'zod';

import { RESOURCE } from './constant';

type BaseItem = {
  id: string;
  name: string;
  createdBy: string;
  uploadDate: Date;
};

export type ResourceFolder = {
  type: typeof RESOURCE.FOLDER;
  depth: number;
} & BaseItem;

export type ResourceFile = {
  type: typeof RESOURCE.FILE;
  size: number;
} & BaseItem;

export type ResourceQueryParams = {
  Cursor?: number;
  Take: number;
  OrderBy?: string;
};

export const createFolderInputSchema = z.object({
  title: z.string().min(1).trim()
});
export type CreateFolderInputSchema = z.infer<typeof createFolderInputSchema>;

export const createFolderAPISchema = z
  .object({
    createdBy: z.string().min(1),
    projectId: z.string().min(1),
    ancestorId: z.string().min(1)
  })
  .and(createFolderInputSchema);
export type CreateFolderAPISchema = z.infer<typeof createFolderAPISchema>;
