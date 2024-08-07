import { queryOptions, useQuery } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { QueryConfig } from '@/lib/react-query';

import { ResourceFolder } from '../types/api';
import { resourceKeys } from '../utils/queries';

export const fetchProjectRootFolder = async (
  projectId: string
): Promise<ResourceFolder | undefined> => {
  const response = await api.get(`/folders/project/${projectId}/root`);
  const folders: ResourceFolder[] = response.data;

  // Find the folder with depth 0
  return folders.find((folder) => folder.depth === 0);
};

export const fetchProjectRootFolderQueryOptions = (projectId: string) => {
  return queryOptions({
    queryKey: resourceKeys.root(projectId),
    queryFn: () => fetchProjectRootFolder(projectId)
  });
};

type UseRootFolderOptions = {
  projectId: string;
  queryConfig?: QueryConfig<typeof fetchProjectRootFolderQueryOptions>;
};

export const useRootFolder = ({ projectId, queryConfig }: UseRootFolderOptions) => {
  return useQuery({
    ...fetchProjectRootFolderQueryOptions(projectId),
    ...queryConfig
  });
};
