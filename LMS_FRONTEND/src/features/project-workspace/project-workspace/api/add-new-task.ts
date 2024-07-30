import { api } from '@/lib/api-client';

interface AddTaskListData {
  name: string;
  maxTasks: number;
  projectId: string;
}

export const addNewTaskList = async (data: AddTaskListData) => {
  const response = await api.post('/task-lists', data);
  return response.data;
};
