import { api } from '@/lib/api-client';

import type { TaskList } from '../types/project-types';

export const getTaskLists = async (projectId: string): Promise<TaskList[]> => {
  const response = await api.get(`/projects/${projectId}/task-lists`);
  return response.data;
};
