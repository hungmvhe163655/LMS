using Entities.Models;
using Shared.DataTransferObjects.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IReportRepository : IRepositoryBase<Report>
    {
        Task<PagedList<Report>> GetReports(ReportRequestParameters param, bool track);
    }
}
