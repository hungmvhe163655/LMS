interface CookieStorage {
  setToken: (token: string) => void;
  getToken: () => string | null;
  clearToken: () => void;
}

export const cookieStorage: CookieStorage = {
  setToken: (token: string): void => {
    document.cookie = `token=${encodeURIComponent(token)}; Secure; SameSite=Strict; path=/;`;
  },

  getToken: (): string | null => {
    const name = 'token=';
    const decodedCookie = decodeURIComponent(document.cookie);
    const ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
      const c = ca[i].trim();
      if (c.indexOf(name) === 0) {
        return c.substring(name.length, c.length);
      }
    }
    return null;
  },

  clearToken: (): void => {
    document.cookie = 'token=; Max-Age=0; Secure; SameSite=Strict; path=/;';
  }
};
