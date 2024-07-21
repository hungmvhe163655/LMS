import { zodResolver } from '@hookform/resolvers/zod';
import { Editor } from '@tiptap/react';
import { Link2 } from 'lucide-react';
import { useState } from 'react';
import { useForm } from 'react-hook-form';
import { z } from 'zod';

import { Button } from '@/components/ui/button';
import {
  Dialog,
  DialogClose,
  DialogContent,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger
} from '@/components/ui/dialog';
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage
} from '@/components/ui/form';
import { Input } from '@/components/ui/input';

const formSchema = z.object({
  url: z.string().url({ message: 'Invalid URL format' }),
  text: z.string().min(1, { message: 'Text field cannot be empty' })
});

export const LinkReference = ({ editor }: { editor: Editor }) => {
  const previousUrl = editor.getAttributes('link').href;
  const { view, state } = editor;
  const { from, to } = view.state.selection;
  const selectText = state.doc.textBetween(from, to, '');
  const [open, setOpen] = useState(false);

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      url: previousUrl,
      text: selectText
    }
  });

  function onSubmit() {
    const values = form.getValues();

    if (values.url === null) {
      form.reset();
      return;
    }

    // empty
    if (values.url === '') {
      editor.chain().focus().extendMarkRange('link').unsetLink().run();
      form.reset();
      return;
    }

    // update link
    editor
      .chain()
      .focus()
      .extendMarkRange('link')
      .setLink({ href: values.url })
      .command(({ tr }) => {
        tr.insertText(values.text);
        return true;
      })
      .run();
    setOpen(false);
    form.reset();
  }

  return (
    <Dialog open={open} onOpenChange={setOpen}>
      <DialogTrigger asChild>
        <Button variant='outline'>
          <Link2 />
        </Button>
      </DialogTrigger>
      <Form {...form}>
        <DialogContent className='sm:max-w-[425px]'>
          <DialogHeader>
            <DialogTitle>Edit Link</DialogTitle>
          </DialogHeader>

          {/* Text */}
          <FormField
            control={form.control}
            name='text'
            render={({ field }) => (
              <FormItem>
                <FormLabel>Text</FormLabel>
                <FormControl>
                  <Input type='text' {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Url */}
          <FormField
            control={form.control}
            name='url'
            render={({ field }) => (
              <FormItem>
                <FormLabel>Url</FormLabel>
                <FormControl>
                  <Input type='url' {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <DialogFooter>
            <DialogClose asChild>
              <Button type='button'>Cancel</Button>
            </DialogClose>
            <Button type='button' onClick={onSubmit}>
              Ok
            </Button>
          </DialogFooter>
        </DialogContent>
      </Form>
    </Dialog>
  );
};
