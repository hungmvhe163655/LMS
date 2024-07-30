import { api } from '@/lib/api-client';

interface CreateProjectData {
  createdBy: string;
  name: string;
  description: string;
  createdDate: string;
  projectStatus: string;
  maxMember: number;
  isRecruiting: boolean;
  projectTypeId: number;
}

export const createProject = async (data: CreateProjectData) => {
  const response = await api.post('/projects', data);
  return response.data;
};
