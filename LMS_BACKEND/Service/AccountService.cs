using AutoMapper;
using Contracts.Interfaces;
using Entities.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class AccountService : IAccountService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public AccountService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public Account GetUserByName(string userName)
        {
            try
            {
                var user = _repository.account.FindByNameAsync(userName, false).Result;
                return user;
            }catch
            {
                throw;
            }
        }
    }
}
