import * as z from 'zod';

const createEnv = () => {
  const EnvSchema = z.object({
    API_URL: z.string(),
    ENABLE_API_MOCKING: z
      .string()
      .refine((s) => s === 'true' || s === 'false')
      .transform((s) => s === 'true')
      .optional(),
    APP_URL: z.string().optional().default('http://localhost:3000'),
    APP_MOCK_API_PORT: z.string().optional().default('8080')
  });

  const envVars = {
    API_URL: '',
    ENABLE_API_MOCKING: 'false',
    APP_URL: 'http://localhost:3000',
    APP_MOCK_API_PORT: '8080',
    ...Object.entries(import.meta.env).reduce<Record<string, string>>((acc, [key, value]) => {
      if (key.startsWith('VITE_APP_')) {
        acc[key.replace('VITE_APP_', '')] = value;
      }
      return acc;
    }, {})
  };

  const parsedEnv = EnvSchema.safeParse(envVars);

  if (!parsedEnv.success) {
    const errors = Object.entries(parsedEnv.error.flatten().fieldErrors)
      .map(([key, errorMessages]) => `- ${key}: ${errorMessages.join(', ')}`)
      .join('\n');
    throw new Error(`Invalid environment variables provided:\n${errors}`);
  }

  return parsedEnv.data;
};

export const env = createEnv();
