using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BACKEND_MAIN.Presentation.Attributes
{
    public class CheckUserFilter : IAsyncActionFilter
    {
        private readonly IServiceManager _service;

        public CheckUserFilter(IServiceManager service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userClaims = context.HttpContext.User.Claims;
            var username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;


            
            await next();
        }
    }
}
