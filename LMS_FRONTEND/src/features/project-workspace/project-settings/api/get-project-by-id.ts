export interface Project {
  id: string;
  name: string;
  description: string;
  // Add other fields as required
}

// Import statements and other code remain the same

import { useQuery, queryOptions } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { QueryConfig } from '@/lib/react-query';

// Function to get project by ID
export const getProjectById = async (projectId: string): Promise<Project> => {
  const response = await api.get(`/projects/${projectId}`);
  return response.data;
};

// Query options for getting project by ID
export const getProjectByIdQueryOptions = (projectId: string) => {
  return queryOptions({
    queryKey: ['project', projectId],
    queryFn: () => getProjectById(projectId)
  });
};

// Define options type for the useProjectById hook
type UseProjectByIdOptions = {
  projectId: string;
  queryConfig?: QueryConfig<typeof getProjectByIdQueryOptions>;
};

// useProjectById hook
export const useProjectById = ({ projectId, queryConfig }: UseProjectByIdOptions) => {
  return useQuery({
    ...getProjectByIdQueryOptions(projectId),
    ...queryConfig
  });
};
