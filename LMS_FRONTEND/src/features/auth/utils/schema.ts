import { z } from 'zod';

export const loginInputSchema = z.object({
  email: z.string().min(1, 'Required').email('Invalid email'),
  password: z.string().min(5, 'Required')
});
export type LoginInput = z.infer<typeof loginInputSchema>;

export const registerInputSchema = z
  .object({
    email: z.string().min(1, 'Required'),
    role: z.enum(['STUDENT', 'SUPERVISOR']),
    fullname: z.string().min(1, 'Required'),
    password: z.string().min(1, 'Required'),
    confirmPassword: z.string().min(1, 'Required'),
    gender: z.boolean({
      required_error: 'Required'
    }),
    phonenumber: z
      .string()
      .min(1, 'Required')
      .regex(/^\d{10}$/, {
        message: 'Phone number must be exactly 10 digits'
      })
  })
  .superRefine(({ confirmPassword, password }, ctx) => {
    if (confirmPassword !== password) {
      ctx.addIssue({
        code: 'custom',
        message: 'The passwords did not match',
        path: ['confirmPassword']
      });
    }
  });
export type RegisterInput = z.infer<typeof registerInputSchema>;
