using Entities.Exceptions;
using Entities.Models;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IReportService
    {
        Task<(IEnumerable<ReportResponseModel> data, MetaData meta)> GetallReportsWithParam(Guid deviceId, ReportRequestParameters param);
        Task<ReportResponseModel> GetReport(Guid id);
        Task<ReportResponseModel> CreateReport(CreateReportRequestModel model);
        Task DeleteReport(Guid id);
        Task UpdateReport(Guid id, UpdateReportRequestModel model);
    }
}
