import { FieldError, UseFormRegister } from 'react-hook-form';

export type FormData = {
  email: string;
  password: string;
  confirmPassword: string;
  phoneNumber: string;
  fullname: string;
};

export type FormFieldProps = {
  type: string;
  placeholder: string;
  name: ValidFieldNames;
  register: UseFormRegister<FormData>;
  error: FieldError | undefined;
  valueAsNumber?: boolean;
};

export type ValidFieldNames = 'email' | 'password' | 'confirmPassword' | 'phoneNumber' | 'fullname';
