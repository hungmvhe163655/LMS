using Microsoft.AspNetCore.Mvc;
using Repository;

namespace LAS_BACKEND_MAIN.Controllers
{
    [Route("api/AUTHEN")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public LoginController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
