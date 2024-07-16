import { createStore, useStore } from 'zustand';
import { devtools, persist } from 'zustand/middleware';
import { useStoreWithEqualityFn } from 'zustand/traditional';

import { LoginData } from '@/types/api';
import { StorageService } from '@/utils/storage-service';

type AuthStore = {
  accessToken: string | undefined;
  accessData: LoginData | undefined;
  refreshToken: string | undefined;

  actions: {
    setAccessToken: (accessToken: string | undefined) => void;
    setRefreshToken: (refreshToken: string | undefined) => void;
    setAccessData: (accessData: LoginData | undefined) => void;

    // set tokens on the app start
    init: () => void;
    clearTokens: () => void;
  };
};

const authStore = createStore<AuthStore>()(
  devtools(
    persist(
      (set, get) => ({
        accessToken: undefined,
        accessData: undefined,
        refreshToken: undefined,

        actions: {
          setAccessToken: (accessToken: string | undefined) => {
            set({
              accessToken
            });
          },
          setRefreshToken: (refreshToken: string | undefined) =>
            set({
              refreshToken
            }),
          setAccessData: (accessData: LoginData | undefined) =>
            set({
              accessData
            }),
          init: () => {
            const { setAccessToken, setRefreshToken } = get().actions;
            setAccessToken(StorageService.getAccessToken());
            setRefreshToken(StorageService.getRefreshToken());
          },
          clearTokens: () =>
            set({
              accessToken: undefined,
              accessData: undefined,
              refreshToken: undefined
            })
        }
      }),
      {
        name: 'auth-store'
      }
    )
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
const accessTokenSelector = (state: ExtractState<typeof authStore>) => state.accessToken;
const accessDataSelector = (state: ExtractState<typeof authStore>) => state.accessData;
const refreshTokenSelector = (state: ExtractState<typeof authStore>) => state.refreshToken;
const actionsSelector = (state: ExtractState<typeof authStore>) => state.actions;

// getters
export const getAccessToken = () => accessTokenSelector(authStore.getState());
export const getAccessData = () => accessDataSelector(authStore.getState());
export const getRefreshToken = () => refreshTokenSelector(authStore.getState());
export const getActions = () => actionsSelector(authStore.getState());

function useAuthStore<U>(selector: Params<U>[1], equalityFn?: Params<U>[2]) {
  return useStoreWithEqualityFn(authStore, selector, equalityFn);
}

// Hooks
export const useAccessToken = () => useAuthStore(accessTokenSelector);
export const useAccessData = () => useAuthStore(accessDataSelector);
export const useRefreshToken = () => useAuthStore(refreshTokenSelector);
export const useActions = () => useAuthStore(actionsSelector);
