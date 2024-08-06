import { useQuery, queryOptions } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { QueryConfig } from '@/lib/react-query';

export type ProjectMember = {
  fullName: string;
  userId: string;
  isLeader: boolean;
  joinDate: string;
};

export const getProjectMembers = async (
  projectId: string | undefined
): Promise<ProjectMember[]> => {
  const response = await api.get(`/projects/${projectId}/members`);
  return response.data;
};

export const getProjectMembersQueryOptions = (projectId: string | undefined) => {
  return queryOptions({
    queryKey: ['project', projectId, 'members'],
    queryFn: () => getProjectMembers(projectId)
  });
};

type UseProjectMembersOptions = {
  projectId: string | undefined;
  queryConfig?: QueryConfig<typeof getProjectMembersQueryOptions>;
};

export const useProjectMembers = ({ projectId, queryConfig }: UseProjectMembersOptions) => {
  return useQuery({
    ...getProjectMembersQueryOptions(projectId),
    ...queryConfig
  });
};
