import { CreateFolderDialog } from './create-folder-dialog';

export function ResourceTableToolbars() {
  return (
    <div className='flex items-center justify-between gap-2'>
      <CreateFolderDialog />
    </div>
  );
}
