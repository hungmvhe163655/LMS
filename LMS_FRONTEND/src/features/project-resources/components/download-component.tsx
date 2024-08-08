import { DownloadIcon } from '@radix-ui/react-icons';
import { saveAs } from 'file-saver';

import { DropdownMenuItem } from '@/components/ui/dropdown-menu';

import { useDownloadFile } from '../api/download-file';

export function DownloadComponent({ id }: { id: string }) {
  const { isLoading, refetch } = useDownloadFile({ fileId: id });

  const handleDownload = async () => {
    const fileData = await refetch().then((res) => res.data);
    if (fileData) {
      const blob = new Blob([fileData]);
      saveAs(blob);
    }
  };

  if (isLoading) {
    return <div>Downloading...</div>;
  }

  return (
    <DropdownMenuItem onSelect={handleDownload}>
      {isLoading ? 'Downloading...' : 'Download'} <DownloadIcon />
    </DropdownMenuItem>
  );
}
