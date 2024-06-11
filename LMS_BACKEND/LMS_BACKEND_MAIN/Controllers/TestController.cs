using Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS_BACKEND_MAIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILoggerManager _loggerManager;
        public TestController(ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
        }
        [HttpGet]
        public IEnumerable<string> Get() {
            _loggerManager.LogInformation("Lmao1");
            _loggerManager.LogDebuger("lmao2");
            _loggerManager.LogWarning("lmao3");
            _loggerManager.LogError("Lmao4");
            var result = new List<string> { "value1", "value2" }; // Replace this with your actual data
            return result;
        }
    }
}
