import { useInfiniteQuery } from '@tanstack/react-query';

import { api } from '@/lib/api-client';

import { ResourceFile, ResourceFolder, ResourceQueryParams } from '../types/api';
import { RESOURCE } from '../types/constant';
import { resourceKeys } from '../utils/queries';

const fetchResources = async (
  id: string,
  params: ResourceQueryParams
): Promise<{ data: (ResourceFile | ResourceFolder)[]; cursor?: number }> => {
  const response = await api.get(`/folders/${id}/content`, { params });
  const folders = response.data.data.folders.map((item: ResourceFolder) => ({
    ...item,
    type: RESOURCE.FOLDER
  }));
  const files = response.data.data.files.map((item: ResourceFile) => ({
    ...item,
    type: RESOURCE.FILE,
    size: item.size
  }));
  return {
    data: [...folders, ...files],
    cursor: response.data.cursor
  };
};

export const useResources = ({
  id,
  resourceQueryParameter
}: {
  id: string;
  resourceQueryParameter: ResourceQueryParams;
}) => {
  return useInfiniteQuery({
    queryKey: resourceKeys.lists(id, resourceQueryParameter),
    queryFn: ({ pageParam = resourceQueryParameter }) => fetchResources(id, pageParam),
    getNextPageParam: (lastPage) => {
      if (lastPage.data.length === 0 || !lastPage.cursor) return undefined; // No more data to fetch

      const nextParams: ResourceQueryParams = {
        ...resourceQueryParameter,
        Cursor: lastPage.cursor
      };
      return nextParams;
    },
    initialPageParam: resourceQueryParameter
  });
};
