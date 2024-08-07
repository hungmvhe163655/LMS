export const taskListKeys = {
  all: ['task-lists'] as const,

  allProjects: () => [...taskListKeys.all, 'project'] as const,
  allProject: (projectId: string) => [...taskListKeys.allProjects(), projectId] as const,

  details: (projectId: string) => [...taskListKeys.allProject(projectId), 'detail'] as const,
  detail: (id: string, projectId: string) => [...taskListKeys.details(projectId), id] as const
};
