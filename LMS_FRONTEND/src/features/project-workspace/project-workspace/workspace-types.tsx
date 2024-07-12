// types.ts
export interface Task {
  id: string;
  title: string;
  createdBy: string;
  predecessorTaskId: string | null;
  requiresValidation: boolean;
  description: string;
  createdDate: string;
  startDate: string;
  dueDate: string;
  taskPriorityId: string;
  taskListId: string;
  projectId: string;
  taskStatusId: string;
  assignedTo: string;
}

export interface TaskList {
  id: string;
  name: string;
  maxTasks: number;
  projectId: string;
  tasks: Task[];
}
