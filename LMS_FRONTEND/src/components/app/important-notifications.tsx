import React from 'react';

interface Notification {
  date: string;
  message: string;
  type: string; // Only 'info' or 'alert'
}

interface NotificationsProps {
  notifications: Notification[];
}

const ImportantNotifications: React.FC<NotificationsProps> = ({ notifications }) => {
  return (
    <div className='rounded-lg bg-blue-100 p-4 shadow-md'>
      <h2 className='mb-2 text-xl font-bold'>Important Notifications</h2>
      {notifications.map((notification, index) => (
        <div
          key={index}
          className={`mb-2 rounded-lg p-2 ${notification.type === 'info' ? 'bg-blue-200' : 'bg-red-200'}`}
        >
          <p className='text-gray-700'>{notification.date}</p>
          <p className='text-gray-900'>{notification.message}</p>
        </div>
      ))}
    </div>
  );
};

export default ImportantNotifications;
