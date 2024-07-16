import { thumbs } from '@dicebear/collection';
import { createAvatar } from '@dicebear/core';
import { useMemo } from 'react';

const useAvatar = (seed: string) => {
  const url = useMemo(() => {
    return createAvatar(thumbs, {
      seed,
      scale: 80
    }).toDataUri();
  }, [seed]);
  return url;
};
export default useAvatar;
