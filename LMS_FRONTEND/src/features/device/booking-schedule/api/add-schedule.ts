// add-booking.ts
import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';

export type AddBookingPayload = {
  deviceId: string;
  accountId: string | undefined;
  startDate: string;
  endDate: string;
  purpose: string;
};

export const addBooking = async (payload: AddBookingPayload): Promise<void> => {
  await api.post('/schedules', payload);
};

export const useAddBooking = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: addBooking,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['schedules-for-device'] }); // Correct query key
    }
  });
};
