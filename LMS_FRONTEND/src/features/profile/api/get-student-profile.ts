import { queryOptions, useQuery } from '@tanstack/react-query';

import { StudentDetail, StudentProfileParams } from '../types/api';

import { api } from '@/lib/api-client';
import { QueryConfig } from '@/lib/react-query';

export const getStudentProfile = async (
  params: StudentProfileParams
): Promise<{ data: StudentDetail }> => {
  const response = await api.get(`/accounts/${params.id}`);
  return response.data;
};

export const getStudentProfileOptions = (params: StudentProfileParams) => {
  return queryOptions({
    queryKey: ['student-profile', params],
    queryFn: () => getStudentProfile(params)
  });
};

type UseStudentProfileOptions = {
  studentProfileQueryParameter: StudentProfileParams;
  queryConfig?: QueryConfig<typeof getStudentProfile>;
};

export const useStudentDetail = ({
  studentProfileQueryParameter,
  queryConfig
}: UseStudentProfileOptions) => {
  return useQuery({
    ...getStudentProfileOptions(studentProfileQueryParameter),
    ...queryConfig
  });
};
