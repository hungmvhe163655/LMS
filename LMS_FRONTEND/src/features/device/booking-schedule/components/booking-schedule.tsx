// booking-schedule.tsx
import {
  DndContext,
  useDraggable,
  useDroppable,
  DragStartEvent,
  DragEndEvent,
  closestCenter
} from '@dnd-kit/core';
import { createSnapModifier } from '@dnd-kit/modifiers';
import React, { useState } from 'react';

import BookingForm from './booking-form';

interface Schedule {
  id: string;
  deviceId: string;
  accountId: string;
  scheduledDate: Date;
  startDate: Date;
  endDate: Date;
  purpose: string;
}

const BookingSchedule: React.FC = () => {
  const hours = Array.from({ length: 24 }, (_, i) => i);
  const days = Array.from(
    { length: 7 },
    (_, i) => new Date(new Date().setDate(new Date().getDate() + i))
  );
  const [schedules, setSchedules] = useState<Schedule[]>([]);
  const [showModal, setShowModal] = useState(false);
  const [selectedDate, setSelectedDate] = useState<Date | null>(null);
  const [selectedHour, setSelectedHour] = useState<number | null>(null);
  const [, setActiveSchedule] = useState<Schedule | null>(null);

  const handleCellClick = (date: Date, hour: number) => {
    setSelectedDate(date);
    setSelectedHour(hour);
    setShowModal(true);
  };

  const handleSave = (schedule: Schedule) => {
    setSchedules((prev) => [...prev, schedule]);
    setShowModal(false);
  };

  const handleDragStart = (event: DragStartEvent) => {
    const schedule = schedules.find((s) => s.id === event.active.id);
    if (schedule) {
      setActiveSchedule(schedule);
    }
  };

  const handleDragEnd = (event: DragEndEvent) => {
    const { active, over } = event;
    if (over) {
      const draggedSchedule = schedules.find((schedule) => schedule.id === active.id);
      if (draggedSchedule) {
        const newDate = days[parseInt(over.id.toString().split('-')[1])];
        const newHour = parseInt(over.id.toString().split('-')[2]);
        draggedSchedule.startDate.setDate(newDate.getDate());
        draggedSchedule.startDate.setHours(newHour);
        draggedSchedule.endDate.setDate(newDate.getDate());
        draggedSchedule.endDate.setHours(newHour + 1); // Assuming 1 hour duration for simplicity
        setSchedules((prev) => [...prev.filter((s) => s.id !== active.id), draggedSchedule]);
      }
    }
    setActiveSchedule(null);
  };

  const cellId = (dayIndex: number, hour: number) => `cell-${dayIndex}-${hour}`;

  return (
    <div>
      <DndContext
        onDragStart={handleDragStart}
        onDragEnd={handleDragEnd}
        collisionDetection={closestCenter}
        modifiers={[createSnapModifier(16)]}
      >
        <div className='grid grid-cols-8 gap-1 bg-gray-300'>
          <div></div>
          {days.map((day, index) => (
            <div key={index} className='bg-gray-100 p-2 text-center'>
              {day.toDateString()}
            </div>
          ))}
          {hours.map((hour) => (
            <React.Fragment key={hour}>
              <div className='bg-gray-100 p-2'>{hour}:00</div>
              {days.map((day, index) => (
                <DroppableCell
                  key={cellId(index, hour)}
                  id={cellId(index, hour)}
                  onCellClick={() => handleCellClick(day, hour)}
                >
                  {schedules
                    .filter((schedule) => {
                      const scheduleDate = new Date(schedule.scheduledDate);
                      return (
                        scheduleDate.toDateString() === day.toDateString() &&
                        new Date(schedule.startDate).getHours() === hour
                      );
                    })
                    .map((schedule) => (
                      <DraggableSchedule key={schedule.id} schedule={schedule} />
                    ))}
                </DroppableCell>
              ))}
            </React.Fragment>
          ))}
        </div>
        {selectedDate && selectedHour !== null && (
          <BookingForm
            show={showModal}
            handleClose={() => setShowModal(false)}
            handleSave={handleSave}
          />
        )}
        {/* <DragOverlay>
          {activeSchedule ? <ScheduleOverlay schedule={activeSchedule} /> : null}
        </DragOverlay> */}
      </DndContext>
    </div>
  );
};

interface DraggableScheduleProps {
  schedule: Schedule;
}

const DraggableSchedule: React.FC<DraggableScheduleProps> = ({ schedule }) => {
  const { attributes, listeners, setNodeRef, transform } = useDraggable({
    id: schedule.id,
    data: { schedule }
  });

  const style = {
    transform: `translate3d(${transform?.x ?? 0}px, ${transform?.y ?? 0}px, 0)`,
    transition: transform ? 'transform 0.2s' : undefined,
    zIndex: 10 // Ensure the schedule is above other elements
  };

  return (
    <div
      ref={setNodeRef}
      style={style}
      {...attributes}
      {...listeners}
      className='absolute inset-0 bg-blue-200'
    >
      {schedule.purpose}
    </div>
  );
};

interface DroppableCellProps {
  id: string;
  children: React.ReactNode;
  onCellClick: () => void;
}

const DroppableCell: React.FC<DroppableCellProps> = ({ id, children, onCellClick }) => {
  const { setNodeRef } = useDroppable({
    id
  });

  return (
    <div
      ref={setNodeRef}
      className='relative h-16 cursor-pointer bg-white'
      onClick={onCellClick}
      role='button'
      tabIndex={0}
      onKeyDown={(e) => {
        if (e.key === 'Enter' || e.key === ' ') {
          onCellClick();
        }
      }}
    >
      {children}
    </div>
  );
};

export default BookingSchedule;
