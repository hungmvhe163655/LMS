import { DragEndEvent } from '@dnd-kit/core';
import {
  useReactTable,
  getCoreRowModel,
  getSortedRowModel,
  OnChangeFn,
  SortingState
} from '@tanstack/react-table';
import { useState, useEffect, useMemo } from 'react';
import InfiniteScroll from 'react-infinite-scroll-component';
import { useMediaQuery } from 'react-responsive';
import { useParams } from 'react-router-dom';

import DragAndDropTable from '@/components/ui/dnd-table/dnd-table';

import { useResources } from '../api/get-resource';
import { ResourceQueryParams } from '../types/api';
import { RESOURCE } from '../types/constant';

import { getColumns } from './resource-columns';
import { ResourceTableToolbars } from './resource-table-toolbar';

export function ResourceTable() {
  const [sorting, setSorting] = useState<SortingState>([]);
  const isBigScreen = useMediaQuery({ query: '(min-width: 1024px)' });
  const [resourceQueryParameter, setResourceQueryParameter] = useState<ResourceQueryParams>({
    Cursor: 0,
    Take: isBigScreen ? 20 : 10,
    OrderBy: 'name.desc'
  });

  const { folderId } = useParams() as { folderId: string };

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
  const { isError, isLoading, data, hasNextPage, fetchNextPage } = useResources({
    id: folderId,
    resourceQueryParameter
  });

  const columns = useMemo(() => getColumns(), []);
  const flatData = useMemo(() => data?.pages.flatMap((page) => page.data), [data]);

  const table = useReactTable({
    data: flatData ?? [],
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

  if (isLoading) {
    return <>Loading...</>;
  }

  if (isError) {
    return <>Error loading resources</>;
  }

  return (
    <InfiniteScroll
      dataLength={flatData?.length ?? 0}
      next={fetchNextPage}
      hasMore={hasNextPage}
      loader={<h4>Loading more items...</h4>}
    >
      <DragAndDropTable table={table} handleDragEnd={handleDragEnd}>
        <ResourceTableToolbars />
      </DragAndDropTable>
    </InfiniteScroll>
  );
}
