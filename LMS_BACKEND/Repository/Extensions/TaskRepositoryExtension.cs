using Entities.Models;
using Repository.Extensions.Utility;
using Shared.DataTransferObjects.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class TaskRepositoryExtension
    {
        public static IQueryable<Tasks> FilterTasks(this IQueryable<Tasks> tasks, DateTime minCreatedDate, DateTime maxCreatedDate, Guid? projectId = null, string? taskStatus = null)
        {
            var filteredTasks = tasks.Where(n => n.CreatedDate >= minCreatedDate && n.CreatedDate <= maxCreatedDate);

            if (projectId != null)
            {
                filteredTasks = filteredTasks.Where(x => x.ProjectId == projectId);
            }

            if (!string.IsNullOrEmpty(taskStatus))
            {
                filteredTasks = filteredTasks.Where(x => x.TaskStatus.ToLower() == taskStatus.ToLower());
            }

            return filteredTasks;
        }
        public static IQueryable<Tasks> Search(this IQueryable<Tasks> tasks, TaskRequestParameters parameters)
        {
            if (string.IsNullOrWhiteSpace(parameters.SearchTerm ?? "")) return tasks;

            var lowerCaseTerm = parameters.SearchTerm == null ? "" : parameters.SearchTerm.Trim().ToLower();

            return tasks.Where(n => n.Title.ToLower().Contains(lowerCaseTerm) || n.Description.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Tasks> Sort(this IQueryable<Tasks> tasks, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return tasks.OrderBy(n => n.CreatedDate);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<News>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return tasks.OrderBy(n => n.CreatedDate);

            return tasks.OrderBy(orderQuery);
        }
    }
}
