import { Editor } from '@tiptap/react';
import { Link2, Link2Off } from 'lucide-react';
import { useCallback, useEffect, useState } from 'react';
import { z } from 'zod';

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
import { Input } from '@/components/ui/input';
import { Label } from '@/components/ui/label';

const urlSchema = z.object({
  url: z.string().url('Invalid URL format').trim(),
  selectedText: z.string().trim()
});

export const LinkReference = ({ editor }: { editor: Editor }) => {
  const [url, setUrl] = useState('');
  const [selectedText, setSelectedText] = useState('');
  const [open, setOpen] = useState(false);
  const [errors, setErrors] = useState<{ url?: string; selectedText?: string }>({});

  useEffect(() => {
    const previousUrl = editor.getAttributes('link').href ?? '';
    const { from, to } = editor.view.state.selection;
    const text = editor.state.doc.textBetween(from, to, '') ?? '';

    setUrl(previousUrl);
    setSelectedText(text);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [editor.view.state.selection, editor.state.doc]);

  const onSubmit = useCallback(() => {
    const result = urlSchema.safeParse({ url, selectedText });

    if (!result.success) {
      const fieldErrors = result.error.format();
      setErrors({
        url: fieldErrors.url?._errors[0],
        selectedText: fieldErrors.selectedText?._errors[0]
      });
      return;
    }

    // clear errors
    setErrors({});

    if (selectedText === '') {
      editor.chain().focus().extendMarkRange('link').setLink({ href: url }).run();
    } else {
      editor
        .chain()
        .focus()
        .extendMarkRange('link')
        .setLink({ href: url })
        .command(({ tr }) => {
          tr.insertText(selectedText);
          return true;
        })
        .run();
    }

    setOpen(false);
    setUrl('');
    setSelectedText('');
  }, [editor, selectedText, url]);

  const handleDialogOpenChange = (isOpen: boolean) => {
    if (isOpen && editor.isActive('link')) {
      editor.chain().focus().unsetLink().run();
    } else {
      setOpen(isOpen);
    }
  };

  return (
    <>
      <Dialog open={open} onOpenChange={handleDialogOpenChange}>
        <DialogTrigger asChild>
          <Button variant='outline'>
            <Link2 />
          </Button>
        </DialogTrigger>

        <DialogContent className='sm:max-w-[425px]'>
          <DialogHeader>
            <DialogTitle>Edit Link</DialogTitle>
            <DialogDescription>Edit your link</DialogDescription>
          </DialogHeader>

          {/* Text */}
          <Label htmlFor='text-url'>Text</Label>
          <Input
            type='text'
            id='text-url'
            value={selectedText}
            onChange={(e) => setSelectedText(e.target.value)}
          />
          {errors.selectedText && <p className='text-red-500'>{errors.selectedText}</p>}

          {/* Url */}
          <Label htmlFor='text-url'>Url</Label>
          <Input type='url' id='url' value={url} onChange={(e) => setUrl(e.target.value)} />
          {errors.url && <p className='text-red-500'>{errors.url}</p>}

          <DialogFooter>
            <DialogClose asChild>
              <Button type='button'>Cancel</Button>
            </DialogClose>
            <Button type='button' onClick={onSubmit}>
              Ok
            </Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
      <Button
        onClick={() => editor.chain().focus().unsetLink().run()}
        disabled={!editor.isActive('link')}
      >
        <Link2Off />
      </Button>
    </>
  );
};
