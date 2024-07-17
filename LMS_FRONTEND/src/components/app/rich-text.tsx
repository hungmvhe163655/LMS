import CharacterCount from '@tiptap/extension-character-count';
import { Color } from '@tiptap/extension-color';
import TextAlign from '@tiptap/extension-text-align';
import TextStyle from '@tiptap/extension-text-style';
import Underline from '@tiptap/extension-underline';
import { EditorContent, useEditor } from '@tiptap/react';
import StarterKit from '@tiptap/starter-kit';
import FontSize from 'tiptap-extension-font-size';

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
          'min-h-[250px] h-[600px] rounded-md border border-gray-300 bg-white p-5 text-sm ring-offset-background placeholder:text-muted-foreground focus-visible:outline-none disabled:cursor-not-allowed disabled:opacity-50 overflow-auto'
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
      FontSize,
      Underline,
      Color
    ],
    content: value, // Set the initial content with the provided value
    onUpdate: ({ editor }) => {
      onChange(editor.getHTML()); // Call the onChange callback with the updated HTML content
    }
  });

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

      <EditorContent editor={editor} />
    </div>
  );
};

export default RichText;
