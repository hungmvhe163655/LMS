import { queryOptions, useQuery } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { QueryConfig } from '@/lib/react-query';

import { resourceKeys } from '../utils/queries';

export const downloadFile = async (fileId: string): Promise<Blob> => {
  const response = await api.get(`/files/download/${fileId}`, {
    responseType: 'blob'
  });
  return response.data;
};

export const downloadFileQueryOptions = (fileId: string) => {
  return queryOptions({
    queryKey: resourceKeys.file(fileId),
    queryFn: () => downloadFile(fileId)
  });
};

type UseDownloadFileOptions = {
  fileId: string;
  queryConfig?: QueryConfig<typeof downloadFileQueryOptions>;
};

export const useDownloadFile = ({ fileId, queryConfig }: UseDownloadFileOptions) => {
  return useQuery({
    ...downloadFileQueryOptions(fileId),
    ...queryConfig
  });
};
