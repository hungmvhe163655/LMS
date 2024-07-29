import { RESOURCE } from './constant';

type BaseItem = {
  id: string;
  name: string;
  createdBy: string;
  createdDate: Date;
};

export type Folder = {
  type: typeof RESOURCE.FOLDER;
} & BaseItem;

export type File = {
  type: typeof RESOURCE.FILE;
  size: number;
} & BaseItem;
