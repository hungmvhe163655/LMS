import { useInfiniteQuery } from '@tanstack/react-query';
import { useMemo } from 'react';

import { api } from '@/lib/api-client';

import { ResourceFile, ResourceFolder, ResourceQueryParams } from '../types/api';
import { RESOURCE } from '../types/constant';
import { fileKeys, folderKeys } from '../utils/queries';

const fetchFiles = async (
  id: string,
  params: ResourceQueryParams
): Promise<{ data: ResourceFile[]; cursor?: number }> => {
  const response = await api.get(`/folders/${id}/content/files`, { params });
  return {
    data: response.data.data,
    cursor: response.data.cursor
  };
};

const fetchFolders = async (
  id: string,
  params: ResourceQueryParams
): Promise<{ data: ResourceFolder[]; cursor?: number; folderRemaining: number }> => {
  const response = await api.get(`/folders/${id}/content/folders`, { params });
  return {
    data: response.data.data,
    cursor: response.data.cursor,
    folderRemaining: params.Take - response.data.data.length
  };
};

export const useResource = ({
  id,
  resourceQueryParameter
}: {
  id: string;
  resourceQueryParameter: ResourceQueryParams;
}) => {
  const folderQuery = useInfiniteQuery({
    queryKey: folderKeys.lists(id, resourceQueryParameter),
    queryFn: () => fetchFolders(id, resourceQueryParameter),
    getNextPageParam: (lastPage) => lastPage.cursor,
    initialPageParam: 0
  });

  const fileQuery = useInfiniteQuery({
    queryKey: fileKeys.lists(id, resourceQueryParameter),
    queryFn: () => fetchFiles(id, resourceQueryParameter),
    getNextPageParam: (lastPage) => lastPage.cursor,
    initialPageParam: 0,
    enabled: !folderQuery.hasNextPage
  });

  const fetchNextResourcePage = async () => {
    if (folderQuery.hasNextPage) {
      folderQuery.fetchNextPage();
    } else if (!folderQuery.isLoading && fileQuery.hasNextPage) {
      fileQuery.fetchNextPage();
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
  const hasMore = folderQuery.hasNextPage || fileQuery.hasNextPage;

  return { isError, isLoading, data, hasMore, fetchNextResourcePage };
};
