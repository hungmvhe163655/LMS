import { ResourceFolder, ResourceFile } from './api';

export const data: (ResourceFolder | ResourceFile)[] = [
  {
    id: 'folder1',
    name: 'Documents',
    createdBy: 'user1',
    createdDate: new Date('2023-01-01'),
    type: 'folder'
  },
  {
    id: 'folder2',
    name: 'Projects',
    createdBy: 'user2',
    createdDate: new Date('2023-01-05'),
    type: 'folder'
  },
  {
    id: 'folder3',
    name: 'Work',
    createdBy: 'user7',
    createdDate: new Date('2023-01-15'),
    type: 'folder'
  },
  {
    id: 'folder4',
    name: 'Photos',
    createdBy: 'user4',
    createdDate: new Date('2023-01-20'),
    type: 'folder'
  },
  {
    id: 'folder5',
    name: 'Personal',
    createdBy: 'user12',
    createdDate: new Date('2023-01-30'),
    type: 'folder'
  },
  {
    id: 'folder6',
    name: 'Miscellaneous',
    createdBy: 'user16',
    createdDate: new Date('2023-02-10'),
    type: 'folder'
  },
  {
    id: 'folder7',
    name: 'Archive',
    createdBy: 'user17',
    createdDate: new Date('2023-02-20'),
    type: 'folder'
  },
  {
    id: 'folder8',
    name: 'Backups',
    createdBy: 'user18',
    createdDate: new Date('2023-03-01'),
    type: 'folder'
  },
  {
    id: 'folder9',
    name: 'Designs',
    createdBy: 'user19',
    createdDate: new Date('2023-03-15'),
    type: 'folder'
  },
  {
    id: 'folder10',
    name: 'Music',
    createdBy: 'user20',
    createdDate: new Date('2023-03-30'),
    type: 'folder'
  },
  {
    id: 'file11',
    name: 'notes.txt',
    createdBy: 'user21',
    createdDate: new Date('2023-04-10'),
    type: 'file',
    size: 1024
  },
  {
    id: 'file12',
    name: 'budget.xlsx',
    createdBy: 'user22',
    createdDate: new Date('2023-04-20'),
    type: 'file',
    size: 20480
  },
  {
    id: 'file13',
    name: 'resume.pdf',
    createdBy: 'user23',
    createdDate: new Date('2023-05-01'),
    type: 'file',
    size: 51200
  },
  {
    id: 'file14',
    name: 'readme.txt',
    createdBy: 'user24',
    createdDate: new Date('2023-06-10'),
    type: 'file',
    size: 1024
  },
  {
    id: 'file15',
    name: 'project.zip',
    createdBy: 'user25',
    createdDate: new Date('2023-07-10'),
    type: 'file',
    size: 512000
  },
  {
    id: 'file16',
    name: 'presentation.pptx',
    createdBy: 'user26',
    createdDate: new Date('2023-07-20'),
    type: 'file',
    size: 256000
  },
  {
    id: 'file17',
    name: 'music.mp3',
    createdBy: 'user27',
    createdDate: new Date('2023-07-25'),
    type: 'file',
    size: 10485760
  },
  {
    id: 'file18',
    name: 'video.mp4',
    createdBy: 'user28',
    createdDate: new Date('2023-07-28'),
    type: 'file',
    size: 52428800
  },
  {
    id: 'file19',
    name: 'archive.tar.gz',
    createdBy: 'user29',
    createdDate: new Date('2023-07-29'),
    type: 'file',
    size: 1048576
  },
  {
    id: 'file20',
    name: 'data.csv',
    createdBy: 'user30',
    createdDate: new Date('2023-07-30'),
    type: 'file',
    size: 20480
  }
];
