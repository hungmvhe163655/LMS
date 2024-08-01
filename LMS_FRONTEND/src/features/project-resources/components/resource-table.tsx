import { DragEndEvent } from '@dnd-kit/core';
import {
  useReactTable,
  getCoreRowModel,
  getSortedRowModel,
  OnChangeFn,
  SortingState
} from '@tanstack/react-table';
import { useRef, useState, useEffect, useMemo } from 'react';

import DragAndDropTable from '@/components/ui/dnd-table/dnd-table';

import { useFiles } from '../api/get-files';
import { useFolders } from '../api/get-folders';
import { ResourceQueryParams } from '../types/api';
import { RESOURCE } from '../types/constant';

import { getColumns } from './resource-columns';

export function ResourceTable() {
  const tableContainerRef = useRef<HTMLDivElement>(null);
  const [sorting, setSorting] = useState<SortingState>([]);
  const [resourceQueryParameter, setResourceQueryParameter] = useState<ResourceQueryParams>({
    Top: undefined,
    Take: undefined,
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
    fetchNextPage: fetchNextFolderPage,
    hasNextPage: hasNextFolderPage,
    isFetchingNextPage: isFetchingNextFolderPage,
    isLoading: isFolderLoading,
    isError: isFolderError
  } = useFolders({
    id: folderId,
    resourceQueryParameter
  });

  // Fetch files if no more folders
  const {
    data: fileData,
    fetchNextPage: fetchNextFilePage,
    hasNextPage: hasNextFilePage,
    isFetchingNextPage: isFetchingNextFilePage,
    isLoading: isFileLoading,
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
    manualSorting: true,
    debugTable: true
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

  useEffect(() => {
    // Store the current ref value in a variable to use in the cleanup function
    const currentContainer = tableContainerRef.current;

    if (currentContainer) {
      const observer = new IntersectionObserver(
        (entries) => {
          if (
            entries[0].isIntersecting &&
            (hasNextFolderPage || hasNextFilePage) &&
            !(isFetchingNextFilePage || isFetchingNextFolderPage)
          ) {
            if (hasNextFolderPage) {
              fetchNextFolderPage();
            } else if (hasNextFilePage) {
              fetchNextFilePage();
            }
          }
        },
        { root: currentContainer, rootMargin: '0px', threshold: 1.0 }
      );

      const lastElement = currentContainer.lastElementChild;
      if (lastElement) {
        observer.observe(lastElement);
      }

      // Cleanup function to unobserve the last element
      return () => {
        if (lastElement) {
          observer.unobserve(lastElement);
        }
      };
    }
  }, [
    fetchNextFolderPage,
    fetchNextFilePage,
    hasNextFolderPage,
    hasNextFilePage,
    isFetchingNextFilePage,
    isFetchingNextFolderPage
  ]);

  if (isFolderLoading || isFileLoading) {
    return <>Loading...</>;
  }

  if (isFolderError || isFileError) {
    return <>Error loading resources</>;
  }

  return (
    <div className='container relative h-[600px] overflow-auto' ref={tableContainerRef}>
      <DragAndDropTable table={table} handleDragEnd={handleDragEnd} />
    </div>
  );
}
