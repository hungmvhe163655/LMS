import { useState, useEffect, useRef } from 'react';

const useCountdown = (initialSeconds: number) => {
  const [seconds, setSeconds] = useState(initialSeconds);
  const intervalRef = useRef<NodeJS.Timeout | null>(null);

  useEffect(() => {
    intervalRef.current = setInterval(() => {
      setSeconds((prevSeconds) => {
        if (prevSeconds <= 1) {
          clearInterval(intervalRef.current as NodeJS.Timeout);
          return 0;
        }
        return prevSeconds - 1;
      });
    }, 1000);

    return () => clearInterval(intervalRef.current as NodeJS.Timeout);
  }, []);

  const reset = () => {
    clearInterval(intervalRef.current as NodeJS.Timeout);
    setSeconds(initialSeconds);
    intervalRef.current = setInterval(() => {
      setSeconds((prevSeconds) => {
        if (prevSeconds <= 1) {
          clearInterval(intervalRef.current as NodeJS.Timeout);
          return 0;
        }
        return prevSeconds - 1;
      });
    }, 1000);
  };

  return { seconds, reset };
};

export default useCountdown;
