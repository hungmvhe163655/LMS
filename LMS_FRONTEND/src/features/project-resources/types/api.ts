import { RESOURCE } from './constant';

type BaseItem = {
  id: string;
  name: string;
  createdBy: string;
  uploadDate: Date;
};

export type ResourceFolder = {
  type: typeof RESOURCE.FOLDER;
} & BaseItem;

export type ResourceFile = {
  type: typeof RESOURCE.FILE;
  size: number;
} & BaseItem;

export type ResourceQueryParams = {
  Top?: number;
  Take?: number;
  OrderBy?: string;
};
