import { createStore } from 'zustand';
import { persist } from 'zustand/middleware';

import { LoginData } from '@/types/api';

type State = {
  accessData: LoginData | null;
};

type Actions = {
  setAccessData: (accessData: LoginData) => void;
  clearAccessData: () => void;
};

const initialState: State = {
  accessData: null
};

export const authStore = createStore<State & Actions>()(
  persist(
    (set) => ({
      ...initialState,
      setAccessData: (accessData: LoginData) => {
        set({ accessData });
      },
      clearAccessData: () => set(initialState)
    }),
    {
      name: 'auth-store'
    }
  )
);
