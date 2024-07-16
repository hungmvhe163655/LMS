﻿using AutoMapper;
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
                .report
                .GetReports(param, false);

            return (_mapper.Map<IEnumerable<ReportResponseModel>>(hold), hold.MetaData);
        }

        public async Task<ReportResponseModel> GetReport(Guid id) =>
            _mapper
            .Map<ReportResponseModel>
            (
                await
                _repository
                .report
                .GetByCondition(x => x.Id.Equals(id), false)
                .FirstOrDefaultAsync()
                ?? throw new BadRequestException("Invalid ID")
            );
        public async Task CreateReport(CreateReportRequestModel model)
        {
            model.Id = Guid.NewGuid();

            _repository.report.Create(_mapper.Map<Report>(model));

            await _repository.Save();
        }
        public async Task DeleteReport(Guid id)
        {
            var hold = await _repository.report.GetByCondition(x => x.Id.Equals(id), false).FirstOrDefaultAsync() ?? throw new BadRequestException("Invalid ID");

            _repository.report.Delete(hold);

            await _repository.Save();
        }
        public async Task UpdateReport(Guid id, UpdateReportRequestModel model)// luc implement leen controller nhow phai them kiem tra sua fiel de con xoa file cu
        {
            var hold = await _repository.report.GetByCondition(x => x.Id.Equals(id), true).FirstOrDefaultAsync() ?? throw new BadRequestException("Invalid ID");

            _mapper.Map(model, hold);

            await _repository.Save();
        }
    }
}
