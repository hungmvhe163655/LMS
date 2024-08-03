import { useState } from 'react';
import { Navigate } from 'react-router-dom';

import { Layout } from '@/components/layouts/profile-layout';
import { ChangeEmailForm } from '@/features/profile/components/change-email-form';
import { ChangeEmailOtpForm } from '@/features/profile/components/change-email-otp-form';
import { useCurrentLoginUser } from '@/hooks/use-current-login-user';

export function EmailPage() {
  const [isOtpStep, setIsOtpStep] = useState(false);
  const { data: user, isLoading } = useCurrentLoginUser();
  const [email, setEmail] = useState(user?.email);

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (!email) {
    return <Navigate to='/' />;
  }

  const handleEmailSubmited = (email: string) => {
    setEmail(() => email);
    setIsOtpStep(() => true);
  };

  const handleReSubmited = () => {
    setIsOtpStep(() => false);
  };

  return (
    <Layout>
      <ChangeEmailForm
        email={email}
        handleEmailSubmited={handleEmailSubmited}
        isOtpStep={isOtpStep}
      />
      {isOtpStep && <ChangeEmailOtpForm email={email} handleReSubmited={handleReSubmited} />}
    </Layout>
  );
}
