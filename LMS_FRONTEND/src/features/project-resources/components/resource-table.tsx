import { DragEndEvent } from '@dnd-kit/core';
import {
  useReactTable,
  getCoreRowModel,
  getSortedRowModel,
  OnChangeFn,
  SortingState
} from '@tanstack/react-table';
import { useState, useEffect, useMemo } from 'react';

import DragAndDropTable from '@/components/ui/dnd-table/dnd-table';
import InfiniteScroll from '@/components/ui/infinite-scroll';

import { useFiles } from '../api/get-files';
import { useFolders } from '../api/get-folders';
import { ResourceQueryParams } from '../types/api';
import { RESOURCE } from '../types/constant';

import { getColumns } from './resource-columns';

export function ResourceTable() {
  const [sorting, setSorting] = useState<SortingState>([]);
  const [resourceQueryParameter, setResourceQueryParameter] = useState<ResourceQueryParams>({
    Top: 0,
    Take: 5,
    OrderBy: 'name.desc'
  });

  const folderId = '0a6457aa-1f74-438c-bd6f-2807710be0cd'; // Replace with your actual folder ID

  useEffect(() => {
    if (sorting.length > 0) {
      const orderBy = sorting[0]?.id || 'name';
      setResourceQueryParameter((prev: ResourceQueryParams) => ({
        ...prev,
        OrderBy: orderBy
      }));
    }
  }, [sorting]);

  // Fetch folders
  const {
    data: folderData,
    hasNextPage: hasNextFolderPage,
    isLoading: isFolderLoading,
    isError: isFolderError,
    fetchNextPage: fetchNextFolderPage
  } = useFolders({
    id: folderId,
    resourceQueryParameter
  });

  // Fetch files if no more folders
  const {
    data: fileData,
    fetchNextPage: fetchNextFilePage,
    isLoading: isFileLoading,
    hasNextPage: hasNextFilePage,
    isError: isFileError
  } = useFiles({
    id: folderId,
    resourceQueryParameter,
    enabled: !hasNextFolderPage
  });

  // Combine folder and file data using useMemo
  const flatFolderData = useMemo(() => {
    return (
      folderData?.pages?.flatMap((page) =>
        page.data.map((item) => ({
          ...item,
          type: RESOURCE.FOLDER
        }))
      ) ?? []
    );
  }, [folderData]);

  const flatFileData = useMemo(() => {
    return (
      fileData?.pages?.flatMap((page) =>
        page.data.map((item) => ({
          ...item,
          type: RESOURCE.FILE,
          size: item.size // Ensure that size is available in the raw data
        }))
      ) ?? []
    );
  }, [fileData]);

  const combinedData = useMemo(
    () => [...flatFolderData, ...flatFileData],
    [flatFolderData, flatFileData]
  );

  const columns = useMemo(() => getColumns(), []);

  const table = useReactTable({
    data: combinedData,
    columns,
    state: { sorting },
    getCoreRowModel: getCoreRowModel(),
    getSortedRowModel: getSortedRowModel(),
    manualSorting: true
  });

  const handleSortingChange: OnChangeFn<SortingState> = (updater) => {
    setSorting(updater);
  };

  table.setOptions((prev) => ({
    ...prev,
    onSortingChange: handleSortingChange
  }));

  const handleDragEnd = (event: DragEndEvent) => {
    const { active, over } = event;
    if (active.id !== over?.id) {
      const activeItem = table.getRowModel().rows.find((row) => row.id === active.id);
      const overItem = table.getRowModel().rows.find((row) => row.id === over?.id);

      if (overItem?.original.type === RESOURCE.FOLDER) {
        // Implement logic to move `activeItem` into `overItem` folder
        console.log(`Move ${activeItem?.original.name} into folder ${overItem.original.name}`);
      }
    }
  };

  if (isFolderLoading || isFileLoading) {
    return <>Loading...</>;
  }

  if (isFolderError || isFileError) {
    return <>Error loading resources</>;
  }

  return (
    <InfiniteScroll
      isLoading={isFolderLoading || isFileLoading}
      hasMore={hasNextFolderPage || hasNextFilePage}
      next={() => {
        if (hasNextFolderPage) {
          fetchNextFolderPage();
        } else if (!hasNextFolderPage && !isFileLoading && !isFileError) {
          fetchNextFilePage();
        }
      }}
      threshold={1}
    >
      <DragAndDropTable table={table} handleDragEnd={handleDragEnd} />
    </InfiniteScroll>
  );
}
