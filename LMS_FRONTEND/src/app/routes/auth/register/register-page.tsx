import { useState } from 'react';
import { useSearchParams } from 'react-router-dom';

import { Link } from '@/components/app/link';
import { Layout } from '@/components/layouts/auth-layout';
import { Card, CardContent, CardFooter } from '@/components/ui/card';
import ChooseRoleRegister from '@/features/auth/components/choose-role';
import RegisterForm from '@/features/auth/components/register-form';
import ValidateEmailForm from '@/features/auth/components/validate-email-form';
import { ValidateOtpForm } from '@/features/auth/components/validate-otp-form';
import { Role } from '@/features/auth/utils/schema';

export function RegisterPage() {
  const [email, setEmail] = useState<string>('');
  const [step, setStep] = useState<'email' | 'otp' | 'role' | 'register'>('email');
  const [selectedRole, setSelectedRole] = useState<Role>('STUDENT');
  const [searchParams] = useSearchParams();
  const redirectTo = searchParams.get('redirectTo');

  const handleEmailSubmit = (submittedEmail: string) => {
    setEmail(submittedEmail);
    setStep('otp');
  };

  const handleOtpValidation = () => {
    setStep('role');
  };

  const handleRoleSelection = (role: Role) => {
    setSelectedRole(role);
    setStep('register');
  };

  const handleBackToEmailForm = () => {
    setStep('email');
  };

  return (
    <Layout title='Register'>
      <Card className='pt-6'>
        <CardContent className='pr-10'>
          {step === 'email' && <ValidateEmailForm onSubmit={handleEmailSubmit} />}
          {step === 'otp' && (
            <ValidateOtpForm
              email={email}
              onBack={handleBackToEmailForm}
              onValidate={handleOtpValidation}
            />
          )}
          {step === 'role' && <ChooseRoleRegister onSelectRole={handleRoleSelection} />}
          {step === 'register' && <RegisterForm email={email} role={selectedRole} />}
        </CardContent>
        <CardFooter>
          <p>
            Already have an account?
            <Link
              to={`/auth/login${redirectTo ? `?redirectTo=${encodeURIComponent(redirectTo)}` : ''}`}
            >
              {' '}
              Login Here!
            </Link>
          </p>
        </CardFooter>
      </Card>
    </Layout>
  );
}