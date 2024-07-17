using Contracts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.DataTransferObjects.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ReportRepository : RepositoryBase<Report>, IReportRepository
    {
        public ReportRepository(DataContext context) : base(context)
        {
        }
        public async Task<PagedList<Report>> GetReports(ReportRequestParameters param, bool track)
        {
           var hold = 
               await 
               FindAll(track)
               .Include(y=>y.Schedules)
               .ThenInclude(t=>t.Device)
               .Include(y=>y.Schedules)
               .ThenInclude(t=>t.Account)
               .Search(param)
               .Skip((param.PageNumber - 1) * param.PageSize)
                .Take(param.PageSize)
               .ToListAsync();

           return new PagedList<Report>(hold, hold.Count, param.PageNumber, param.PageSize);
        }
           
    }
}
