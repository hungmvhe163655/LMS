import { useState } from 'react';

import { Layout } from '@/components/layouts/auth-layout';
import { Card, CardContent } from '@/components/ui/card';
import ValidateEmailForm from '@/features/auth/components/validate-email-form';
import { ValidateOtpForm } from '@/features/auth/components/validate-otp-form';

export function ValidateEmailPage() {
  const [email, setEmail] = useState<string>('');
  const [isOtpFormVisible, setIsOtpFormVisible] = useState<boolean>(false);

  const handleEmailSubmit = (submittedEmail: string) => {
    setEmail(submittedEmail);
    setIsOtpFormVisible(true);
  };

  const handleBackToEmailForm = () => {
    setIsOtpFormVisible(false);
  };

  return (
    <Layout title='Validate Your Email'>
      <Card className='pt-6'>
        <CardContent className='pr-10'>
          {!isOtpFormVisible ? (
            <ValidateEmailForm onSubmit={handleEmailSubmit} />
          ) : (
            <ValidateOtpForm email={email} onBack={handleBackToEmailForm} />
          )}
        </CardContent>
      </Card>
    </Layout>
  );
}
