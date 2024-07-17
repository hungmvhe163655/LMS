using Entities.Models;
using Repository.Extensions.Utility;
using Shared.DataTransferObjects.RequestParameters;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class ProjectRepositoryExtension
    {
        public static IQueryable<Project> FilterProjects(this IQueryable<Project> projects, DateTime minCreatedDate, DateTime maxCreatedDate) => projects.Where(n => (DateTime.Compare(n.CreatedDate, minCreatedDate) > 0 && (DateTime.Compare(n.CreatedDate, maxCreatedDate) < 0)));

        public static IQueryable<Project> Search(this IQueryable<Project> projects, ProjectRequestParameters parameters)
        {
            if (string.IsNullOrWhiteSpace(parameters.SearchTerm ?? "")) return projects;

            var lowerCaseTerm = parameters.SearchTerm == null ? "" : parameters.SearchTerm.Trim().ToLower();

            return projects.Where(n => n.Name.ToLower().Contains(lowerCaseTerm) || n.Description.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Project> Sort(this IQueryable<Project> projects, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return projects.OrderBy(n => n.CreatedDate);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<News>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return projects.OrderBy(n => n.CreatedDate);

            return projects.OrderBy(orderQuery);
        }
    }
}
