import { z } from 'zod';

const createEnv = () => {
  // Define the schema for environment variables
  const EnvSchema = z.object({
    API_URL: z.string(),
    ENABLE_API_MOCKING: z
      .string()
      .refine((s) => s === 'true' || s === 'false')
      .transform((s) => s === 'true')
      .optional(),
    APP_URL: z.string().optional().default('http://localhost:5002')
  });

  // Extract environment variables from import.meta.env and merge with default values
  const envVars = {
    API_URL: '',
    ENABLE_API_MOCKING: 'false',
    APP_URL: 'http://localhost:5002',
    ...Object.entries(import.meta.env).reduce<Record<string, string>>((acc, [key, value]) => {
      if (key.startsWith('VITE_APP_')) {
        acc[key.replace('VITE_APP_', '')] = value;
      }
      return acc;
    }, {})
  };

  // Validate the environment variables against the schema
  const parsedEnv = EnvSchema.safeParse(envVars);

  // Handle validation errors
  if (!parsedEnv.success) {
    const errors = Object.entries(parsedEnv.error.flatten().fieldErrors)
      .map(([key, errorMessages]) => `- ${key}: ${errorMessages.join(', ')}`)
      .join('\n');
    throw new Error(`Invalid environment variables provided:\n${errors}`);
  }

  // Return the validated and parsed environment variables
  return parsedEnv.data;
};

// Export the environment variables
export const env = createEnv();
