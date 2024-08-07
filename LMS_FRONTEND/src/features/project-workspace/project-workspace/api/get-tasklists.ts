import { useQuery, queryOptions } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { QueryConfig } from '@/lib/react-query';

import type { TaskList } from '../types/project-types';
import { taskListKeys } from '../utils/queries';

export const getTaskLists = async (projectId: string): Promise<TaskList[]> => {
  const response = await api.get(`/projects/${projectId}/task-lists`);
  return response.data;
};

export const getTaskListsQueryOptions = (projectId: string) => {
  return queryOptions({
    queryKey: taskListKeys.details(projectId),
    queryFn: () => getTaskLists(projectId)
  });
};

type UseTaskListsOptions = {
  projectId: string;
  queryConfig?: QueryConfig<typeof getTaskListsQueryOptions>;
};

export const useTaskLists = ({ projectId, queryConfig }: UseTaskListsOptions) => {
  return useQuery({
    ...getTaskListsQueryOptions(projectId),
    ...queryConfig
  });
};
