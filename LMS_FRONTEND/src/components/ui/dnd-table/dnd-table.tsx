import {
  DndContext,
  DragEndEvent,
  closestCenter,
  useSensor,
  useSensors,
  MouseSensor,
  TouchSensor,
  KeyboardSensor
} from '@dnd-kit/core';
import { flexRender, Table as TanstackTable } from '@tanstack/react-table';
import React from 'react';

import {
  Table,
  TableBody,
  TableHead,
  TableHeader,
  TableRow,
  TableCell
} from '@/components/ui/table';

import InfiniteScroll from '../infinite-scroll';

import { DndRow } from './dnd-row';

interface DragAndDropTableProps<TData> {
  table: TanstackTable<TData>;
  handleDragEnd: (event: DragEndEvent) => void;
  isLoading: boolean;
  hasMore: boolean;
  next: () => unknown;
}

const DragAndDropTable: React.FC<DragAndDropTableProps<any>> = ({
  table,
  handleDragEnd,
  isLoading,
  hasMore,
  next
}) => {
  const sensors = useSensors(
    useSensor(MouseSensor),
    useSensor(TouchSensor),
    useSensor(KeyboardSensor)
  );

  return (
    <DndContext sensors={sensors} collisionDetection={closestCenter} onDragEnd={handleDragEnd}>
      <div className='relative w-full overflow-auto'>
        <Table>
          <TableHeader>
            {table.getHeaderGroups().map((headerGroup) => (
              <TableRow key={headerGroup.id}>
                {headerGroup.headers.map((header) => (
                  <TableHead key={header.id}>
                    {header.isPlaceholder
                      ? null
                      : flexRender(header.column.columnDef.header, header.getContext())}
                  </TableHead>
                ))}
              </TableRow>
            ))}
          </TableHeader>
          <TableBody>
            {table.getRowModel().rows.length ? (
              table.getRowModel().rows.map((row) => (
                <DndRow key={row.id} row={row}>
                  {row.getVisibleCells().map((cell) => (
                    <TableCell key={cell.id}>
                      {flexRender(cell.column.columnDef.cell, cell.getContext())}
                    </TableCell>
                  ))}
                </DndRow>
              ))
            ) : (
              <TableRow>
                <TableCell colSpan={table.getAllColumns().length} className='h-24 text-center'>
                  No results.
                </TableCell>
              </TableRow>
            )}
            <InfiniteScroll hasMore={hasMore} isLoading={isLoading} next={next} />
          </TableBody>
        </Table>
      </div>
    </DndContext>
  );
};

export default DragAndDropTable;
