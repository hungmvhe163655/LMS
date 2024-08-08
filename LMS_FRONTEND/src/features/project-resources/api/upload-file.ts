import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

import { UploadFileAPISchema } from '../types/api';
import { resourceKeys } from '../utils/queries';

export const uploadFile = async (data: UploadFileAPISchema) => {
  const formData = new FormData();
  formData.append('file', data.file);

  const res = await api.post(`/files/upload/${data.folderId}`, formData, {
    headers: {
      'Content-Type': 'multipart/form-data'
    }
  });

  return res.data;
};

type UseUploadFileOptions = {
  mutationConfig?: MutationConfig<typeof uploadFile>;
};

export const useUploadFile = ({ mutationConfig }: UseUploadFileOptions = {}) => {
  const queryClient = useQueryClient();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    ...restConfig,
    mutationFn: uploadFile,
    onSuccess: (data, variables, context) => {
      queryClient.invalidateQueries({
        queryKey: resourceKeys.content(variables.folderId)
      });
      onSuccess?.(data, variables, context);
    }
  });
};
