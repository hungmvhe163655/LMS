﻿using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AccountController(IServiceManager service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Get(string userName)
        {
            try
            {
                var user =
                _service.accountService.GetUserByName(userName);
                return Ok(user);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}