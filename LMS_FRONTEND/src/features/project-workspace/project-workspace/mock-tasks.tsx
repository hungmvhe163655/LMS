// mockData.js
export const mockTaskLists = [
  {
    id: '1',
    name: 'Current sprint',
    maxTasks: 5,
    projectId: '1',
    tasks: [
      {
        id: '9',
        title: 'Code login frontend',
        createdBy: 'User1',
        predecessorTaskId: null,
        requiresValidation: false,
        description: 'Implement login functionality',
        createdDate: '2024-01-01',
        startDate: '2024-01-02',
        dueDate: '2024-01-10',
        taskPriorityId: '1',
        taskListId: '1',
        projectId: '1',
        taskStatusId: '1',
        assignedTo: 'You'
      },
      {
        id: '10',
        title: 'Code student dashboard frontend',
        createdBy: 'User2',
        predecessorTaskId: '1',
        requiresValidation: true,
        description: 'Implement student dashboard',
        createdDate: '2024-01-02',
        startDate: '2024-01-05',
        dueDate: '2024-01-15',
        taskPriorityId: '2',
        taskListId: '1',
        projectId: '1',
        taskStatusId: '2',
        assignedTo: 'You'
      }
    ]
  },
  {
    id: '2',
    name: 'Testing',
    maxTasks: 10,
    projectId: '1',
    tasks: [
      {
        id: '11',
        title: 'Sample task',
        createdBy: 'User3',
        predecessorTaskId: null,
        requiresValidation: false,
        description: 'Sample description',
        createdDate: '2024-01-03',
        startDate: '2024-01-04',
        dueDate: '2024-01-20',
        taskPriorityId: '3',
        taskListId: '2',
        projectId: '1',
        taskStatusId: '3',
        assignedTo: 'You'
      }
    ]
  }
];
