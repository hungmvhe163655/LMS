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
import { cn } from '@/lib/utils';

import DndRow from './dnd-row';

interface DragAndDropTableProps<TData> extends React.HTMLAttributes<HTMLDivElement> {
  table: TanstackTable<TData>;
  handleDragEnd: (event: DragEndEvent) => void;
  nonDraggableColumns?: string[];
}

const DragAndDropTable: React.FC<DragAndDropTableProps<any>> = ({
  table,
  handleDragEnd,
  children,
  className,
  nonDraggableColumns = [],
  ...props
}) => {
  const sensors = useSensors(
    useSensor(MouseSensor),
    useSensor(TouchSensor),
    useSensor(KeyboardSensor)
  );

  return (
    <div className={cn('w-full space-y-2.5 overflow-auto', className)} {...props}>
      {children}
      <DndContext sensors={sensors} collisionDetection={closestCenter} onDragEnd={handleDragEnd}>
        <div className='relative w-full overflow-auto'>
          <Table className='flex size-full flex-col'>
            <TableHeader
              className='table shrink-0 grow-0 table-fixed'
              style={{ width: 'calc(100% - 0.9em)' }}
            >
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
            <TableBody className='block shrink grow overflow-y-scroll'>
              {table.getRowModel().rows.length ? (
                table.getRowModel().rows.map((row) => (
                  <DndRow key={row.id} row={row} nonDraggableColumns={nonDraggableColumns}>
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
            </TableBody>
          </Table>
        </div>
      </DndContext>
    </div>
  );
};

export default DragAndDropTable;
