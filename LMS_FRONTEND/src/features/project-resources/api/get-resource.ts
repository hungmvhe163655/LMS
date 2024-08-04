import { useInfiniteQuery } from '@tanstack/react-query';
import { useMemo, useState } from 'react';

import { api } from '@/lib/api-client';

import { ResourceFile, ResourceFolder, ResourceQueryParams } from '../types/api';
import { RESOURCE } from '../types/constant';
import { fileKeys, folderKeys } from '../utils/queries';

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

const fetchFolders = async (
  id: string,
  params?: ResourceQueryParams
): Promise<{ data: ResourceFolder[]; remainingData: number }> => {
  const response = await api.get(`/folders/${id}/content/folders`, { params });
  return {
    data: response.data.listObject,
    remainingData: response.data.remainingData
  };
};

export const useResource = ({
  id,
  resourceQueryParameter
}: {
  id: string;
  resourceQueryParameter: ResourceQueryParams;
}) => {
  const [remainingTake, setRemainingTake] = useState(resourceQueryParameter.Take || 0);

  const folderQuery = useInfiniteQuery({
    queryKey: folderKeys.lists(id, resourceQueryParameter),
    queryFn: async ({ pageParam = resourceQueryParameter }) => {
      const result = await fetchFolders(id, pageParam);
      const totalFetchedFolders = result.data.length;
      const newRemainingTake = (resourceQueryParameter.Take || 0) - totalFetchedFolders;
      setRemainingTake(newRemainingTake > 0 ? newRemainingTake : 0);
      return result;
    },
    getNextPageParam: (lastPage) => {
      const nextTake = resourceQueryParameter.Take;

      return lastPage.remainingData > 0 ? { ...resourceQueryParameter, Take: nextTake } : undefined;
    },
    initialPageParam: resourceQueryParameter
  });

  const fileQuery = useInfiniteQuery({
    queryKey: fileKeys.lists(id, { ...resourceQueryParameter, Take: remainingTake }),
    queryFn: ({ pageParam = resourceQueryParameter }) =>
      fetchFiles(id, { ...pageParam, Take: remainingTake }),
    getNextPageParam: (lastPage) => {
      return lastPage.remainingData > 0
        ? { ...resourceQueryParameter, Take: lastPage.remainingData }
        : undefined;
    },
    initialPageParam: resourceQueryParameter,
    enabled: remainingTake > 0 // Start fetching files only when folders are fully fetched and there is a remaining take
  });

  const fetchNextResourcePage = async () => {
    if (folderQuery.hasNextPage) {
      await folderQuery.fetchNextPage();
    } else if (fileQuery.hasNextPage) {
      await fileQuery.fetchNextPage();
    }
  };

  const flatFolderData = useMemo(() => {
    return (
      folderQuery.data?.pages?.flatMap((page) =>
        page.data.map((item) => ({
          ...item,
          type: RESOURCE.FOLDER
        }))
      ) ?? []
    );
  }, [folderQuery.data]);

  const flatFileData = useMemo(() => {
    return (
      fileQuery.data?.pages?.flatMap((page) =>
        page.data.map((item) => ({
          ...item,
          type: RESOURCE.FILE,
          size: item.size
        }))
      ) ?? []
    );
  }, [fileQuery.data]);

  const data = useMemo(() => [...flatFolderData, ...flatFileData], [flatFolderData, flatFileData]);

  const isLoading = folderQuery.isLoading || fileQuery.isLoading;
  const isError = folderQuery.isError || fileQuery.isError;
  const remainingFiles = fileQuery.data?.pages?.[0].remainingData; // Just check File, no more files then it's over
  const hasMore = remainingFiles === undefined || remainingFiles > 0;

  return { isError, isLoading, data, hasMore, fetchNextResourcePage };
};
