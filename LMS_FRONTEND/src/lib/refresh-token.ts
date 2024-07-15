import axios from 'axios';

import { StorageService } from '@/utils/storage-service';

export const refreshToken = async () => {
  const token = {
    accessToken: StorageService.getAccessToken(),
    refreshToken: StorageService.getRefreshToken()
  };

  if (token) {
    return null;
  }

  const response = await axios.post('/token/refresh-token', token);

  const newToken = response.data;

  StorageService.setAccessToken(newToken.accessToken);
  StorageService.setRefreshToken(newToken.refreshToken);

  return newToken.accessToken;
};
