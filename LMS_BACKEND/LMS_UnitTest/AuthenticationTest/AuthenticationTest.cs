using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using Service;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using Shared.GlobalVariables;
using Xunit;

namespace LMS_UnitTest.AuthenticationTest
{


    public class AuthenticationServiceTests
    {
        private readonly Mock<ILoggerManager> _loggerMock;

        private readonly Mock<IMapper> _mapperMock;

        private readonly Mock<UserManager<Account>> _userManagerMock;

        private readonly Mock<RoleManager<IdentityRole>> _roleManagerMock;

        private readonly Mock<IRepositoryManager> _repositoryManagerMock;

        private readonly Mock<IConfiguration> _configurationMock;

        private readonly AuthenticationService _authService;


        public AuthenticationServiceTests()
        {
            _loggerMock = new Mock<ILoggerManager>();

            _mapperMock = new Mock<IMapper>();

            _userManagerMock = new Mock<UserManager<Account>>(new Mock<IUserStore<Account>>().Object, null, null, null, null, null, null, null, null);

            _roleManagerMock = new Mock<RoleManager<IdentityRole>>(new Mock<IRoleStore<IdentityRole>>().Object, null, null, null, null);

            _repositoryManagerMock = new Mock<IRepositoryManager>();

            _configurationMock = new Mock<IConfiguration>();

            _configurationMock.Setup(c => c.GetSection(It.IsAny<string>())).Returns(new Mock<IConfigurationSection>().Object);
            _authService = new AuthenticationService(
                _loggerMock.Object,
                _mapperMock.Object,
                _userManagerMock.Object,
                _configurationMock.Object,
                _roleManagerMock.Object,
                _repositoryManagerMock.Object);
        }

        [Fact]
        public async Task Register_WithValidInput_ReturnsAccountReturnModel()
        {
            var registerRequest = new RegisterRequestModel
            {
                Email = "test@example.com",
                Password = "Test@1234",
                FullName = "Lmao123",
                Roles = new List<string> { ROLES.STUDENT },
                VerifiedByUserID = "verifierId"
            };

            var account = new Account { Id = "newUserId", Email = registerRequest.Email };

            _mapperMock.Setup(m => m.Map<Account>(registerRequest)).Returns(account);

            var verifier = new Account { Id = "verifierId" };
            _userManagerMock.Setup(um => um.FindByIdAsync(registerRequest.VerifiedByUserID)).ReturnsAsync(verifier);

            _userManagerMock.Setup(um => um.GetRolesAsync(verifier)).ReturnsAsync(new List<string> { ROLES.SUPERVISOR });

            _roleManagerMock.Setup(rm => rm.RoleExistsAsync(It.IsAny<string>())).ReturnsAsync(true);

            _userManagerMock.Setup(um => um.CreateAsync(It.IsAny<Account>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);

            _userManagerMock.Setup(um => um.AddToRolesAsync(It.IsAny<Account>(), It.IsAny<IEnumerable<string>>())).ReturnsAsync(IdentityResult.Success);

            _userManagerMock.Setup(um => um.FindByEmailAsync(registerRequest.Email)).ReturnsAsync(account);

            var studentDetail = new StudentDetail { AccountId = account.Id, RollNumber = registerRequest.RollNumber };

            _repositoryManagerMock.Setup(rm => rm.StudentDetail.Create(It.IsAny<StudentDetail>()));

            _repositoryManagerMock.Setup(rm => rm.Save()).Returns(Task.CompletedTask);

            var accountReturnModel = new AccountReturnModel { Id = account.Id, Email = account.Email };

            _mapperMock.Setup(m => m.Map<AccountReturnModel>(It.IsAny<Account>())).Returns(accountReturnModel);

            var result = await _authService.Register(registerRequest);

            Assert.NotNull(result);

            Assert.Equal(registerRequest.Email, result.Email);
        }

        [Fact]
        public async Task Register_InvalidVerifierId_ThrowsBadRequestException()
        {
            var registerRequest = new RegisterRequestModel
            {
                Email = "test@example.com",
                Password = "Test@1234",
                FullName = "Lmao123",
                Roles = new List<string> { ROLES.STUDENT },
                VerifiedByUserID = "invalidVerifierId"
            };

            _userManagerMock.Setup(um => um.FindByIdAsync(registerRequest.VerifiedByUserID)).ReturnsAsync((Account)null);

            await Assert.ThrowsAsync<BadRequestException>(() => _authService.Register(registerRequest));
        }

        [Fact]
        public async Task Register_UnauthorizedVerifier_ThrowsBadRequestException()
        {
            var registerRequest = new RegisterRequestModel
            {
                Email = "test@example.com",
                Password = "Test@1234",
                FullName = "Lmao123",
                Roles = new List<string> { ROLES.STUDENT },
                VerifiedByUserID = "verifierId"
            };

            var verifier = new Account { Id = "verifierId" };

            _userManagerMock.Setup(um => um.FindByIdAsync(registerRequest.VerifiedByUserID)).ReturnsAsync(verifier);

            _userManagerMock.Setup(um => um.GetRolesAsync(verifier)).ReturnsAsync(new List<string> { ROLES.STUDENT });

            await Assert.ThrowsAsync<BadRequestException>(() => _authService.Register(registerRequest));
        }
    }

}
