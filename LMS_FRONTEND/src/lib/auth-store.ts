import { createStore, useStore } from 'zustand';
import { persist } from 'zustand/middleware';
import { useStoreWithEqualityFn } from 'zustand/traditional';

import { LoginData } from '@/types/api';

type AuthStore = {
  accessData: LoginData | null;

  actions: {
    setAccessData: (accessData: LoginData | null) => void;
    clearAccessData: () => void;
  };
};

const authStore = createStore<AuthStore>()(
  persist(
    (set) => ({
      accessData: null,

      actions: {
        setAccessData: (accessNewData: LoginData | null) =>
          set({
            accessData: accessNewData
          }),

        clearAccessData: () => {
          set({
            accessData: null
          });
        }
      }
    }),
    {
      name: 'auth-store'
    }
  )
);

/**
 * Required for zustand stores, as the lib doesn't expose this type
 */
export type ExtractState<S> = S extends {
  getState: () => infer T;
}
  ? T
  : never;

type Params<U> = Parameters<typeof useStore<typeof authStore, U>>;

// Selectors
const accessDataSelector = (state: ExtractState<typeof authStore>) => state.accessData;
const actionsSelector = (state: ExtractState<typeof authStore>) => state.actions;

// getters
export const getAccessData = () => accessDataSelector(authStore.getState());
export const getActions = () => actionsSelector(authStore.getState());

function useAuthStore<U>(selector: Params<U>[1], equalityFn?: Params<U>[2]) {
  return useStoreWithEqualityFn(authStore, selector, equalityFn);
}

// Hooks
export const useAccessData = () => useAuthStore(accessDataSelector);
export const useActions = () => useAuthStore(actionsSelector);
