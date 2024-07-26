import { Button } from '@/components/ui/button';
import {
  Dialog,
  DialogClose,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger
} from '@/components/ui/dialog';
import { useToast } from '@/components/ui/use-toast';

import { useVerifyAccounts } from '../api/verify-account';

interface ConfirmValidationDialogProps {
  userId: string[]; // or number, depending on your data type
  isAccept: boolean;
  onSuccess?: () => void;
}

export function ConfirmValidationDialog({
  userId,
  isAccept,
  onSuccess
}: ConfirmValidationDialogProps) {
  const { mutate: verifyAccounts } = useVerifyAccounts();
  const { toast } = useToast();

  function handleVerify() {
    verifyAccounts(
      { userId },
      {
        onSuccess: () => {
          toast({
            variant: 'success',
            description: 'Verify success'
          });
          onSuccess?.();
        }
      }
    );
  }

  return (
    <Dialog>
      <DialogTrigger asChild>
        <Button variant={isAccept ? 'success' : 'destructive'}>
          {isAccept ? 'Accept' : 'Decline'}
        </Button>
      </DialogTrigger>
      <DialogContent className='sm:max-w-[425px]'>
        <DialogHeader>
          <DialogTitle>Confirm Dialog</DialogTitle>
          <DialogDescription>
            Are you sure {isAccept ? 'accept' : 'decline'} this request?
          </DialogDescription>
        </DialogHeader>
        <DialogFooter>
          <Button onClick={handleVerify}>Yes</Button>
          <DialogClose asChild>
            <Button type='button' variant='secondary'>
              Close
            </Button>
          </DialogClose>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
}
