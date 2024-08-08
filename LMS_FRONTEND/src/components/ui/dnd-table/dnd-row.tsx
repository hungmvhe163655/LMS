import { useDraggable, useDroppable } from '@dnd-kit/core';
import { CSS } from '@dnd-kit/utilities';
import { CSSProperties } from 'react';

import { TableRow } from '@/components/ui/table';

interface DndRowProps {
  row: any;
  children: React.ReactNode;
}

export const DndRow: React.FC<DndRowProps> = ({ row, children }) => {
  const {
    attributes,
    listeners,
    setNodeRef: setDraggableRef,
    transform,
    isDragging
  } = useDraggable({
    id: row.id
  });

  const { setNodeRef: setDroppableRef, isOver } = useDroppable({
    id: row.id
  });

  const style: CSSProperties = {
    transform: CSS.Transform.toString(transform),
    opacity: isDragging ? 0.8 : 1,
    zIndex: isDragging ? 1 : 0,
    backgroundColor: isOver ? 'lightgreen' : 'lightgray',
    position: 'relative',
    width: '100%',
    display: 'table',
    tableLayout: 'fixed'
  };

  return (
    <TableRow
      ref={(node) => {
        setDraggableRef(node);
        setDroppableRef(node);
      }}
      style={style}
      className='w-full'
      {...attributes}
      {...listeners}
    >
      {children}
    </TableRow>
  );
};

export default DndRow;
