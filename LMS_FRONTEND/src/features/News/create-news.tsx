import React, { useState } from 'react';
import FroalaEditor from 'react-froala-wysiwyg';
import 'froala-editor/css/froala_editor.pkgd.min.css';
import 'froala-editor/css/froala_style.min.css';
import 'froala-editor/css/plugins.pkgd.min.css';
import 'froala-editor/css/themes/gray.min.css';

const CreateNews: React.FC = () => {
  const [title, setTitle] = useState('');
  const [content, setContent] = useState('');

  const handleTitleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setTitle(e.target.value);
  };

  const handleContentChange = (model: string) => {
    setContent(model);
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    console.log('Title:', title);
    console.log('Content:', content);
    // Submit logic here
  };

  return (
    <div className='flex flex-col items-center justify-center min-h-screen px-4'>
      <form onSubmit={handleSubmit} className='w-full max-w-3xl space-y-6'>
        <div>
          <label className='block text-lg font-semibold mb-2' htmlFor='news-title'>
            News title
          </label>
          <input
            id='news-title'
            type='text'
            value={title}
            onChange={handleTitleChange}
            className='w-full border border-gray-300 rounded px-4 py-2'
            placeholder='Enter news title'
            required
          />
        </div>
        <div>
          <label className='block text-lg font-semibold mb-2' htmlFor='news-content'>
            News content
          </label>
          <FroalaEditor
            tag='textarea'
            model={content}
            onModelChange={handleContentChange}
            config={{
              placeholderText: 'Enter news content',
              height: 300
            }}
          />
        </div>
        <button type='submit' className='bg-blue-500 text-white px-6 py-2 rounded'>
          Create News
        </button>
      </form>
    </div>
  );
};

export default CreateNews;
