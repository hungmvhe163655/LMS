import ls from 'localstorage-slim';

const ACCESS_TOKEN_KEY = 'accessToken';
const REFRESH_TOKEN_KEY = 'refreshToken';

ls.config.encrypt = true;
ls.config.secret = 50;

export function setAccessToken(token: string) {
  ls.set(ACCESS_TOKEN_KEY, token);
}

export function getAccessToken(): string | undefined {
  return ls.get(ACCESS_TOKEN_KEY) ?? undefined;
}

export function setRefreshToken(token: string) {
  ls.set(REFRESH_TOKEN_KEY, token);
}

export function getRefreshToken(): string | undefined {
  return ls.get(REFRESH_TOKEN_KEY) ?? undefined;
}

export function clearTokens() {
  ls.clear();
}
