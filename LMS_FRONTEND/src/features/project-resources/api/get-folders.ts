import { keepPreviousData, useInfiniteQuery } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { QueryConfig } from '@/lib/react-query';

import { ResourceFolder, ResourceQueryParams } from '../types/api';
import { folderKeys } from '../utils/queries';

const fetchFolders = async (
  id: string,
  params?: ResourceQueryParams
): Promise<{ data: ResourceFolder[]; remainingData: number }> => {
  const response = await api.get(`/folders/${id}/content/folders`, { params });
  return {
    data: response.data.listObject,
    remainingData: response.data.remaining
  };
};

const getFolderQueryOptions = (id: string, params?: ResourceQueryParams) => ({
  queryKey: folderKeys.lists(id, params),
  queryFn: () => fetchFolders(id, { ...params }),
  getNextPageParam: (lastPage: { data: ResourceFolder[]; remainingData: number }) => {
    return lastPage.remainingData > 0 ? lastPage.data.length : undefined;
  },
  initialPageParam: 0
});

type UseFoldersOptions = {
  id: string;
  resourceQueryParameter?: ResourceQueryParams;
  queryConfig?: QueryConfig<typeof getFolderQueryOptions>;
};

export const useFolders = ({ id, resourceQueryParameter, queryConfig }: UseFoldersOptions) => {
  return useInfiniteQuery({
    ...getFolderQueryOptions(id, resourceQueryParameter),
    ...queryConfig,
    placeholderData: keepPreviousData
  });
};
