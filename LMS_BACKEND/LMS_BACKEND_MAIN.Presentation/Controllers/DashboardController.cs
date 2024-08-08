using Entities.Exceptions;
using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Contracts;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using Shared.GlobalVariables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route(APIs.DashboardAPI)]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
    public class DashboardController : ControllerBase
    {
        private readonly IServiceManager _service;

        public DashboardController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet(RoutesAPI.GetNotification)]
        public async Task<IActionResult> GetImportantNotification()
        {
            var param = new NotificationParameters
            {
                PageNumber = 1,
                PageSize = 5,
                UserId = await _service.AccountService.CheckUser(User)
            };

            var hold = await _service.NotificationService.GetPagedNotifications(param);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(hold.MetaData));

            return Ok(hold);
        }

        [HttpGet(RoutesAPI.GetOngoingProject)]
        [Authorize(Roles = Roles.ADMIN_SUPER)]
        public async Task<IActionResult> GetOngoingProject()
        {
            var param = new ProjectRequestParameters
            {
                PageNumber= 1,
                PageSize = 1,
            };
            var current = await _service.AccountService.CheckUser(User);

            var pageResult = await _service.ProjectService.GetProjects(current, param, trackChange: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pageResult.metaData));

            return Ok(pageResult.projects);
        }

        [HttpGet(RoutesAPI.GetOverallReport)]
        [Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> GetOverallReport()
        {
            var project = await _service.ProjectService.CountProject(PROJECT_STATUS.ONGOING);
            var account = await _service.AccountService.CountMember();
            var device = await _service.DeviceService.CountDevice(DEVICE_STATUS.AVAILABLE) + await _service.DeviceService.CountDevice(DEVICE_STATUS.INUSE);

            var report = new OverallResponseModel
            {
                ActiveProject = project,
                Device = device,
                Member = account
            };

            return Ok(report);
        }

        [HttpGet(RoutesAPI.GetMemberReport)]
        [Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> GetMemberReport()
        {
            var data = await _service.AccountService.GetActiveMember();
            return Ok(data);
        }

        [HttpGet(RoutesAPI.GetActiveProject)]
        [Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> GetActiveProject()
        {
            var initializing = await _service.ProjectService.CountProject(PROJECT_STATUS.INITIALIZING);
            var ongoing = await _service.ProjectService.CountProject(PROJECT_STATUS.ONGOING);
            var completed = await _service.ProjectService.CountProject(PROJECT_STATUS.COMPLETED);
            var cancel = await _service.ProjectService.CountProject(PROJECT_STATUS.CANCEL);

            var data = new ProjectReportModel
            {
                Initializing = initializing,
                Ongoing = ongoing,
                Completed = completed,
                Cancel = cancel
            };

            return Ok(data);
        }

        [HttpGet(RoutesAPI.GetDeviceReport)]
        [Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> GetDeviceReport()
        {
            var inUse = await _service.DeviceService.CountDevice(DEVICE_STATUS.INUSE);
            var available = await _service.DeviceService.CountDevice(DEVICE_STATUS.AVAILABLE);
            var disable = await _service.DeviceService.CountDevice(DEVICE_STATUS.DISABLE);

            var data = new DeviceReportModel
            {
                Available = available,
                Disable = disable,
                InUse = inUse
            };

            return Ok(data);
        }
    }
}
