using Entities.Models;
using Shared.DataTransferObjects.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class ReportRepositoryExtentions
    {
        public static IQueryable<Report> Search(this IQueryable<Report> data, ReportRequestParameters parameters)
        {
            var hold = data;

            if (!parameters.DeviceID.Equals(Guid.Empty)) hold = data.Where(x => x.Schedules.DeviceId.Equals(parameters.DeviceID));

            if (string.IsNullOrWhiteSpace(parameters.SearchContent ?? "")) return hold;

            var lowerCaseTerm = parameters.SearchContent == null ? "" : parameters.SearchContent.Trim().ToLower();

            hold = hold.Where(n => n.Schedules.Device.Name != null && n.Schedules.Device.Name.ToLower().Contains(lowerCaseTerm));

            return hold;
        }
    }
}
