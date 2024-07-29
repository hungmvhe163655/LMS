import * as React from 'react';
import { createRoot } from 'react-dom/client';

import './index.css';
import './assets/global.css';
import App from './app/app';

const root = document.getElementById('root');
if (!root) throw new Error('No root element found');

createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);
