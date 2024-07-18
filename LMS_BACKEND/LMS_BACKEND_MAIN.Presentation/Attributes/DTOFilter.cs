using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BACKEND_MAIN.Presentation.Attributes
{
    public class DTOFilter : IActionFilter
    {
        public DTOFilter()
        { }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];
            var param = context.ActionArguments.SingleOrDefault(x => x.Value.ToString().ToLower().Contains("dto")).Value;
            if (param is null)
            {
                context.Result = new BadRequestObjectResult($"Object is null. Controller:{controller}, action: {action} ");
                return;
            }
            if (!context.ModelState.IsValid)
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);

        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
