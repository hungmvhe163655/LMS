import { defaultStyles, FileIcon } from 'react-file-icon';
import { FaFolder } from 'react-icons/fa';

import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow
} from '@/components/ui/scrollable-table';
import { humanFileSize } from '@/utils/format-file-size';
import { getFileExtension } from '@/utils/get-file-extension';

import { RESOURCE } from '../types/constant';
import { data } from '../types/data';

export function ResourceTable() {
  return (
    <div className='w-full'>
      <div className='rounded-md border shadow-md'>
        <div className='relative h-screen overflow-auto'>
          <Table>
            <TableHeader className='sticky top-0 bg-secondary'>
              <TableRow>
                <TableHead>Name</TableHead>
                <TableHead>Created By</TableHead>
                <TableHead>Created Date</TableHead>
                <TableHead>Size</TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              {data.map((item) => {
                const ext = getFileExtension(item.name); // Extract file extension

                return (
                  <TableRow key={item.id}>
                    <TableCell className='flex items-center'>
                      {item.type === RESOURCE.FILE ? (
                        <div className='flex items-center space-x-2'>
                          <div className='flex size-6 items-center justify-center'>
                            <FileIcon
                              extension={ext}
                              {...defaultStyles[ext as keyof typeof defaultStyles]}
                            />
                          </div>
                          <span>{item.name}</span>
                        </div>
                      ) : (
                        <div className='flex items-center space-x-2'>
                          <FaFolder className='size-6' />
                          <span>{item.name}</span>
                        </div>
                      )}
                    </TableCell>
                    <TableCell>{item.createdBy}</TableCell>
                    <TableCell>{item.createdDate.toDateString()}</TableCell>
                    <TableCell>
                      {item.type === RESOURCE.FILE ? humanFileSize(item.size) : '-'}
                    </TableCell>
                  </TableRow>
                );
              })}
            </TableBody>
          </Table>
        </div>
      </div>
    </div>
  );
}
