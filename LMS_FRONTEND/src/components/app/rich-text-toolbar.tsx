import { Editor } from '@tiptap/react';
import {
  AlignCenter,
  AlignJustify,
  AlignLeft,
  AlignRight,
  Baseline,
  Bold,
  ChevronDown,
  Italic,
  List,
  ListOrdered,
  Redo2,
  Underline,
  Undo2
} from 'lucide-react';
import { useState } from 'react';
import { HexColorInput, HexColorPicker } from 'react-colorful';

import { Button } from '../ui/button';
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuTrigger
} from '../ui/dropdown-menu';
import { Popover, PopoverContent, PopoverTrigger } from '../ui/popover';
import { Separator } from '../ui/separator';
import { Toggle } from '../ui/toggle';

const fontSizes = ['12', '14', '16', '18', '20', '24', '28'];

const RichTextToolbar = ({ editor }: { editor: Editor }) => {
  const [textAlign, setTextAlign] = useState<'left' | 'right' | 'center' | 'justify'>('left');
  const [color, setColor] = useState('#000000');
  const [fontSize, setFontSize] = useState('16');

  return (
    <div className='flex w-fit flex-row items-center gap-1 rounded-b-md p-1'>
      <Toggle
        size='sm'
        className=''
        pressed={editor.isActive('bold')}
        onPressedChange={() => editor.chain().focus().toggleBold().run()}
      >
        <Bold className='size-4' />
      </Toggle>
      <Toggle
        size='sm'
        pressed={editor.isActive('italic')}
        onPressedChange={() => editor.chain().focus().toggleItalic().run()}
      >
        <Italic className='size-4' />
      </Toggle>
      <Toggle
        size='sm'
        pressed={editor.isActive('strike')}
        onPressedChange={() => editor.chain().focus().toggleUnderline().run()}
      >
        <Underline className='size-4' />
      </Toggle>
      <Separator orientation='vertical' className='h-8 w-px' />
      <Toggle
        size='sm'
        pressed={editor.isActive('bulletList')}
        onPressedChange={() => editor.chain().focus().toggleBulletList().run()}
      >
        <List className='size-4' />
      </Toggle>
      <Toggle
        size='sm'
        pressed={editor.isActive('orderedList')}
        onPressedChange={() => editor.chain().focus().toggleOrderedList().run()}
      >
        <ListOrdered className='size-4' />
      </Toggle>
      <Separator orientation='vertical' className='h-8 w-px' />
      <Button
        size='sm'
        type='button'
        onClick={() => editor.chain().focus().undo().run()}
        disabled={!editor.can().undo()}
      >
        <Undo2 className='size-4' />
      </Button>
      <Button
        size='sm'
        type='button'
        onClick={() => editor.chain().focus().redo().run()}
        disabled={!editor.can().redo()}
      >
        <Redo2 className='size-4' />
      </Button>
      <Separator orientation='vertical' className='h-8 w-px' />
      <DropdownMenu>
        <DropdownMenuTrigger>
          <span className='inline-flex h-10 items-center justify-center rounded-md bg-primary px-4 py-2 text-primary-foreground hover:bg-primary/90 focus:bg-none'>
            {textAlign === 'left' && <AlignLeft />}
            {textAlign === 'right' && <AlignRight />}
            {textAlign === 'center' && <AlignCenter />}
            {textAlign === 'justify' && <AlignJustify />}
            <ChevronDown />
          </span>
        </DropdownMenuTrigger>
        <DropdownMenuContent className='flex'>
          <DropdownMenuItem
            onClick={() => {
              editor.chain().focus().setTextAlign('left').run();
              setTextAlign('left');
            }}
          >
            <AlignLeft />
          </DropdownMenuItem>
          <DropdownMenuItem
            onClick={() => {
              editor.chain().focus().setTextAlign('center').run();
              setTextAlign('center');
            }}
          >
            <AlignCenter />
          </DropdownMenuItem>
          <DropdownMenuItem
            onClick={() => {
              editor.chain().focus().setTextAlign('right').run();
              setTextAlign('right');
            }}
          >
            <AlignRight />
          </DropdownMenuItem>
          <DropdownMenuItem
            onClick={() => {
              editor.chain().focus().setTextAlign('justify').run();
              setTextAlign('justify');
            }}
          >
            <AlignJustify />
          </DropdownMenuItem>
        </DropdownMenuContent>
      </DropdownMenu>
      <Separator orientation='vertical' className='h-8 w-px' />
      <Popover>
        <PopoverTrigger asChild className='data-[state=open]:bg-slate-200'>
          <Button className='bg-transparent hover:bg-slate-200'>
            <Baseline color={color} />
          </Button>
        </PopoverTrigger>
        <PopoverContent className='w-fit p-1' onFocusOutside={(e) => e.preventDefault()}>
          <HexColorPicker
            color={color}
            onChange={(newColor) => {
              setColor(newColor);
              editor.chain().focus().setColor(newColor).run();
            }}
          />
          <HexColorInput
            color={color}
            className='mt-2 w-full text-center'
            onChange={(newColor) => {
              setColor(newColor);
              editor.chain().focus().setColor(newColor).run();
            }}
          />
        </PopoverContent>
      </Popover>
      <DropdownMenu>
        <DropdownMenuTrigger>
          <span className='inline-flex h-10 min-w-10 max-w-10 items-center justify-center rounded-md border border-primary p-4 font-semibold text-black hover:bg-gray-200 focus:border-0'>
            {fontSize}
          </span>
        </DropdownMenuTrigger>
        <DropdownMenuContent className='min-w-fit'>
          {fontSizes.map((size) => (
            <DropdownMenuItem
              className='p-3 text-base'
              key={size}
              onClick={() => {
                editor
                  .chain()
                  .focus()
                  .setFontSize(size + 'px')
                  .run();
                setFontSize(size);
              }}
            >
              {size}
            </DropdownMenuItem>
          ))}
        </DropdownMenuContent>
      </DropdownMenu>
    </div>
  );
};

export default RichTextToolbar;
