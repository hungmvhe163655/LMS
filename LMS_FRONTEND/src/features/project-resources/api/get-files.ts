import { keepPreviousData, useInfiniteQuery } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { QueryConfig } from '@/lib/react-query';

import { ResourceFile, ResourceQueryParams } from '../types/api';
import { fileKeys } from '../utils/queries';

const fetchFiles = async (
  id: string,
  params?: ResourceQueryParams
): Promise<{ data: ResourceFile[]; remainingData: number }> => {
  const response = await api.get(`/folders/${id}/content/files`, { params });
  return {
    data: response.data.listObject,
    remainingData: response.data.remainingData
  };
};

const getFileQueryOptions = (id: string, params?: ResourceQueryParams) => ({
  queryKey: fileKeys.lists(id, params),
  queryFn: () => fetchFiles(id, { ...params }),
  getNextPageParam: (lastPage: { data: ResourceFile[]; remainingData: number }) => {
    return lastPage.remainingData > 0 ? lastPage.data.length : undefined;
  },
  initialPageParam: 0
});

type UseFilesOptions = {
  id: string;
  resourceQueryParameter?: ResourceQueryParams;
  enabled: boolean;
  queryConfig?: QueryConfig<typeof getFileQueryOptions>;
};

export const useFiles = ({ id, resourceQueryParameter, enabled, queryConfig }: UseFilesOptions) => {
  return useInfiniteQuery({
    ...getFileQueryOptions(id, resourceQueryParameter),
    ...queryConfig,
    placeholderData: keepPreviousData,
    enabled
  });
};
