﻿using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using Shared.GlobalVariables;

namespace Service
{
    public class ScheduleService : IScheduleService
    {
        private readonly IRepositoryManager _repository;

        private readonly IMapper _mapper;
        public ScheduleService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;

            _mapper = mapper;
        }

        private static (DateTime, DateTime) GetWeek(DateTime input)
        {
            DateTime startOfWeek = input.AddDays(-(int)input.DayOfWeek + (int)DayOfWeek.Monday).Date;

            DateTime endOfWeek = startOfWeek.AddDays(6).Date;

            return (startOfWeek, endOfWeek);
        }

        private static (DateTime, DateTime) GetMonth(DateTime input)
        {
            DateTime startOfMonth = new DateTime(input.Year, input.Month, 1);

            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            return (startOfMonth, endOfMonth);
        }

        public async Task<IEnumerable<ScheduleResponseModel>> GetScheduleForDevice(ScheduleRequestModel model, Guid id)
        {
            if (model == null) throw new BadRequestException("lamao");

            var (startTime, EndTime) = (model.TimeFrame != null && model.TimeFrame.Equals(TIME_FRAME.WEEK)) ? GetWeek(model.DateInput) : GetMonth(model.DateInput);

            var result = _mapper.Map<IEnumerable<ScheduleResponseModel>>(await _repository.Schedule.GetScheduleByDevice(id, startTime, EndTime, false));

            return result;
        }
        public async Task<ScheduleResponseModel> CreateScheduleForDevice(ScheduleCreateRequestModel model)
        {
            var hold = _mapper.Map<Schedule>(model);

            hold.ScheduledDate = DateTime.Now;

            hold.Id = Guid.NewGuid();

            if (!await _repository.Schedule.CheckForOverlap(model.StartDate, model.EndDate, model.DeviceId))
            {
                await _repository.Schedule.CreateScheduleForDevice(_mapper.Map<Schedule>(model));

                await _repository.Save();

                return _mapper.Map<ScheduleResponseModel>(hold);
            }
            throw new BadRequestException("The inputted time period was invalid");
        }
        public async Task DeleteSchedule(Guid id)
        {
            var hold = await _repository.Schedule.GetSchedule(id, false);

            if (hold == null) throw new BadRequestException("No schedule with such Id exsited");

            if (hold.EndDate <= DateTime.Now) throw new UnauthorizedException("The booking schedule was already finished");

            //if (hold.StartDate <= DateTime.Now) throw new UnauthorizedException("The booking schedule is already in progress ");

            _repository.Schedule.DeleteSchedule(hold);

            await _repository.Save();
        }
        public async Task UpdateSchedule(Guid id, ScheduleUpdateRequestModel model)
        {
            if (model.EndDate <= model.StartDate) throw new BadRequestException("EndDate can not be smaller than StartDate");

            if (model.EndDate <= DateTime.Now || model.StartDate < DateTime.Now) throw new BadRequestException("Can not create schedule with datetime before current time");

            var hold = await _repository.Schedule.GetSchedule(id, true);

            if (hold == null) throw new BadRequestException("No schedule with such Id existed");

            if (!await _repository.Schedule.CheckForOverlap(model.StartDate, model.EndDate, hold.DeviceId))
            {
                hold.StartDate = model.StartDate;

                hold.EndDate = model.EndDate;

                await _repository.Save();
            }
            throw new BadRequestException("The inputted time period was invalid");

        }

        public async Task<ScheduleRequestModel> GetSchedule(Guid id)
        {
            var hold = await _repository.Schedule.GetSchedule(id, false);

            return _mapper.Map<ScheduleRequestModel>(hold);
        }

        public async Task<IEnumerable<Schedule>> GetDueSchedulesAsync()
        {
            var hold = await _repository.Schedule.GetDueSchedules(DateTime.Now, 10).ToListAsync();

            return hold;
        }
    }
}
