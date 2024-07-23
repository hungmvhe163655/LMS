import CharacterCount from '@tiptap/extension-character-count';
import { Color } from '@tiptap/extension-color';
import Link from '@tiptap/extension-link';
import TextAlign from '@tiptap/extension-text-align';
import TextStyle from '@tiptap/extension-text-style';
import Underline from '@tiptap/extension-underline';
import { EditorContent, useEditor } from '@tiptap/react';
import StarterKit from '@tiptap/starter-kit';
import { EditorState } from 'prosemirror-state';
import { useEffect } from 'react';

import RichTextEditorToolbar from './rich-text-toolbar';

type RichTextEditorProps = {
  value: string;
  onChange: (value: string) => void;
  limit: number | null;
};

const RichText = ({ value, onChange, limit }: RichTextEditorProps) => {
  const editor = useEditor({
    editorProps: {
      attributes: {
        class:
          'min-h-[70vh] max-h-[70vh] rounded-md border border-gray-300 bg-white p-5 text-sm ring-offset-background placeholder:text-muted-foreground focus-visible:outline-none disabled:cursor-not-allowed disabled:opacity-50 overflow-auto'
      }
    },
    extensions: [
      StarterKit.configure({
        orderedList: {
          HTMLAttributes: {
            class: 'list-decimal pl-4'
          }
        },
        bulletList: {
          HTMLAttributes: {
            class: 'list-disc pl-4'
          }
        },
        heading: false
      }),
      CharacterCount.configure({
        limit
      }),
      TextAlign.configure({
        types: ['paragraph']
      }),
      TextStyle,
      Underline,
      Color,
      Link.configure({
        autolink: true,
        defaultProtocol: 'https',
        HTMLAttributes: {
          class: 'font-medium text-blue-600 dark:text-blue-500 hover:underline hover:cursor-pointer'
        }
      }).extend({
        inclusive: false
      })
    ],
    content: value,
    onUpdate: ({ editor }) => {
      onChange(editor.getHTML()); // Call the onChange callback with the updated HTML content
    }
  });

  useEffect(() => {
    if (editor?.isEmpty) {
      editor.commands.setContent(value);
      // The following code clears the history. Hopefully without side effects.
      const newEditorState = EditorState.create({
        doc: editor.state.doc,
        plugins: editor.state.plugins,
        schema: editor.state.schema
      });
      editor.view.updateState(newEditorState);
    }
  }, [value, editor]);

  if (!editor) {
    return <div>Something went wrong!</div>;
  }

  return (
    <div className='flex flex-col justify-stretch space-y-3'>
      <div className='flex justify-between'>
        <RichTextEditorToolbar editor={editor} />
        {limit && (
          <div className='prose flex flex-col justify-end font-medium'>
            <div>
              {editor.storage.characterCount.characters()} / {limit} characters
            </div>
            <div>{editor.storage.characterCount.words()} words</div>
          </div>
        )}
      </div>

      <EditorContent className='flex flex-1 flex-col' editor={editor} />
    </div>
  );
};

export default RichText;
