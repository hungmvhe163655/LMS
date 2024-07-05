import axios from 'axios';

import { getAccessToken, getRefreshToken, setAccessToken, setRefreshToken } from '@/utils/storage';

export const refreshToken = async () => {
  const token = {
    accessToken: getAccessToken(),
    refreshToken: getRefreshToken()
  };

  const response = await axios.post('/token/refresh-token', token);

  const newToken = response.data;

  setAccessToken(newToken.accessToken);
  setRefreshToken(newToken.refreshToken);

  return newToken.accessToken;
};
