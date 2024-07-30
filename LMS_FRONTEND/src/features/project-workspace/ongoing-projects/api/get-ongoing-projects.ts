import { queryOptions, useQuery } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { QueryConfig } from '@/lib/react-query';

export type Project = {
  id: string;
  name: string;
  description: string;
  taskUndone: number;
  createdDate: Date;
  projectStatusId: number;
  maxMember: number;
  isRecruiting: boolean;
  projectTypeId: number;
};

export type ProjectQueryParams = {
  userId: string;
  PageNumber: number;
  PageSize: number;
};

export const getOngoingProjects = async (
  params: ProjectQueryParams
): Promise<{ data: Project[]; pagination: any }> => {
  const { userId, PageNumber, PageSize } = params;
  if (!userId) {
    return { data: [], pagination: {} };
  }
  const response = await api.get(`/projects/user/${userId}`, {
    params: { PageNumber, PageSize }
  });
  const pagination = JSON.parse(response.headers['x-pagination']);
  return { data: response.data, pagination };
};

export const getOngoingProjectsQueryOptions = (params: ProjectQueryParams) => {
  return queryOptions({
    queryKey: ['ongoing-projects', params],
    queryFn: () => getOngoingProjects(params)
  });
};

type UseOngoingProjectsOptions = {
  projectQueryParams: ProjectQueryParams;
  queryConfig?: QueryConfig<typeof getOngoingProjectsQueryOptions>;
};

export const useOngoingProjects = ({
  projectQueryParams,
  queryConfig
}: UseOngoingProjectsOptions) => {
  return useQuery({
    ...getOngoingProjectsQueryOptions(projectQueryParams),
    ...queryConfig
  });
};
