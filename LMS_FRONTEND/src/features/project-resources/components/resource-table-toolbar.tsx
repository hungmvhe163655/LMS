import { CreateFolderDialog } from './create-folder-dialog';
import { UploadFileDialog } from './upload-file-dialog';

export function ResourceTableToolbars() {
  return (
    <div className='flex items-center justify-between gap-2'>
      <CreateFolderDialog />
      <UploadFileDialog />
    </div>
  );
}
