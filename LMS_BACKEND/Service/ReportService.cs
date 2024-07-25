using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ReportService : IReportService
    {
        private readonly IRepositoryManager _repository;

        private readonly IMapper _mapper;

        public ReportService(IRepositoryManager repository, IMapper mapper)
        {
            _mapper = mapper;

            _repository = repository;
        }
        public async Task<(IEnumerable<ReportResponseModel> data, MetaData meta)> GetallReportsWithParam(Guid deviceId, ReportRequestParameters param)
        {
            var hold = await
            _repository
                .Report
                .GetReports(param, false);

            return (_mapper.Map<IEnumerable<ReportResponseModel>>(hold), hold.MetaData);
        }

        public async Task<ReportResponseModel> GetReport(Guid id) =>
            _mapper
            .Map<ReportResponseModel>
            (
                await
                _repository
                .Report
                .GetByCondition(x => x.Id
                .Equals(id), false)
                .FirstOrDefaultAsync()
                ?? throw new BadRequestException("Invalid ID")
            );
        public async Task<ReportResponseModel> CreateReport(CreateReportRequestModel model)
        {
            var hold = _mapper.Map<Report>(model);

            hold.Id = Guid.NewGuid();

            _repository.Report.Create(hold);

            await _repository.Save();

            return _mapper.Map<ReportResponseModel>(hold);
        }
        public async Task<string?> DeleteReport(Guid id)
        {
            var hold = await _repository.Report.GetByCondition(x => x.Id.Equals(id), false).FirstOrDefaultAsync() ?? throw new BadRequestException("Invalid ID");

            var hold_image = hold.FileKey;

            _repository.Report.Delete(hold);

            await _repository.Save();

            return hold_image;
        }
        public async Task<string?> UpdateReport(Guid id, UpdateReportRequestModel model)// luc implement leen controller nhow phai them kiem tra sua fiel de con xoa file cu
        {
            var hold = await _repository.Report.GetByCondition(x => x.Id.Equals(id), true).FirstOrDefaultAsync() ?? throw new BadRequestException("Invalid ID");

            var compare = hold.FileKey != null ? hold.FileKey.Equals(model.FileKey) : false;

            string end = "";

            if(compare) end = model.FileKey;

            _mapper.Map(model, hold);

            await _repository.Save();

            return end;
        }
    }
}
