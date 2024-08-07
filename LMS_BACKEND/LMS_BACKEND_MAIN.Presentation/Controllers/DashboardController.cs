using Entities.Exceptions;
using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Contracts;
using Shared.DataTransferObjects.RequestParameters;
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

        private async Task<string> CheckUser()
        {
            var userClaims = User.Claims;

            var username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            var hold = await _service.AccountService.GetUserByName(username ?? throw new UnauthorizedException("lamao"));

            return hold.Id;
        }

        [HttpGet(RoutesAPI.GetNotification)]
        public async Task<IActionResult> GetImportantNotification()
        {
            var param = new NotificationParameters
            {
                PageNumber = 1,
                PageSize = 5,
                UserId = CheckUser().Result
            };

            var hold = await _service.NotificationService.GetPagedNotifications(param);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(hold.MetaData));

            return Ok(hold);
        }

        [HttpGet(RoutesAPI.GetOngoingProject)]
        public async Task<IActionResult> GetOngoingProject()
        {
            var param = new ProjectRequestParameters
            {
                PageNumber= 1,
                PageSize = 1,
            };

            var pageResult = await _service.ProjectService.GetProjects(CheckUser().Result, param, trackChange: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pageResult.metaData));

            return Ok(pageResult.projects);
        }
    }
}
