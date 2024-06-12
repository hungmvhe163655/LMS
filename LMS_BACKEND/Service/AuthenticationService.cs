using AutoMapper;
using Contracts.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<Account> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthenticationService(ILoggerManager logger, IMapper mapper, UserManager<Account> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> RegisterStudent(StudentRegisterRequestModel model)
        {
            try
            {
                var user = _mapper.Map<Account>(model);
                if (string.IsNullOrEmpty(model.Password))
                {
                    return IdentityResult.Failed();
                }
                var rolesToAdd = model.Roles != null ? model.Roles : null;
                var validRoles = new List<string>();
                if (rolesToAdd != null && rolesToAdd.Any()) foreach (var role in rolesToAdd)
                    {
                        if (await _roleManager.RoleExistsAsync(role))
                        {
                            validRoles.Add(role);
                        }
                        else
                        {
                            _logger.LogWarning($"Role '{role}' does not exist.");
                        }
                    }
                if (validRoles.Any())
                {
                    var result = await _userManager.CreateAsync(user, model.Password);
                    await _userManager.AddToRolesAsync(user, validRoles);
                    return result;
                }
                return IdentityResult.Failed();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error During Authentication Process has Occur for Student");
                _logger.LogError(ex.Message);
                return IdentityResult.Failed();
            }

        }
    }
}
