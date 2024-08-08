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
  name: z.string().min(1).trim()
});
export type CreateFolderInputSchema = z.infer<typeof createFolderInputSchema>;

export const createFolderAPISchema = z
  .object({
    ancestorId: z.string().min(1)
  })
  .and(createFolderInputSchema);
export type CreateFolderAPISchema = z.infer<typeof createFolderAPISchema>;

export const updateFolderAPISchema = z
  .object({
    id: z.string().min(1)
  })
  .and(createFolderInputSchema);
export type UpdateFolderFolderAPISchema = z.infer<typeof updateFolderAPISchema>;

export const uploadFileInputSchema = z.object({
  file: z.instanceof(File).refine((file) => file.size <= 15 * 1024 * 1024, {
    message: 'File size must not exceed 15 MB'
  })
});
export type UploadFileInputSchema = z.infer<typeof uploadFileInputSchema>;

export const uploadFileAPISchema = z
  .object({
    folderId: z.string().min(1)
  })
  .and(uploadFileInputSchema);
export type UploadFileAPISchema = z.infer<typeof uploadFileAPISchema>;
