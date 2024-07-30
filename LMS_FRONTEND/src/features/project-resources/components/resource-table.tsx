import { DragEndEvent } from '@dnd-kit/core';
import { useMemo } from 'react';

import DragAndDropTable from '@/components/ui/dnd-table/dnd-table';
import { useDataTable } from '@/hooks/use-data-table';

import { RESOURCE } from '../types/constant';
import { data } from '../types/data';

import { getColumns } from './resource-columns';

export function ResourceTable() {
  // Memoize the columns so they don't re-render on every render
  const columns = useMemo(() => getColumns(), []);

  const { table } = useDataTable({
    data: data || [],
    pageCount: 0,
    columns
  });

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

  return <DragAndDropTable table={table} handleDragEnd={handleDragEnd} />;
}
