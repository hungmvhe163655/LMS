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
       // public async Task<Account> GetUserByEmail(string email) =>  _repository.account.GetByCondition(entity => entity.Email.Equals(email), false).FirstOrDefault();
        public async Task<Account> GetUserByEmail(string email)
        {
            var end = await _repository.account.GetByConditionAsync(entity => entity.Email.Equals(email), false);
            return end.First();
        }
        public async Task<Account> GetUserByName(string userName)
        {
            try
            {
                var user = await _repository.account.FindByNameAsync(userName, false);
                return user;
            }catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateAccountVerifyStatus(IEnumerable<string> userEmailList)
        {
            List<Account> accountList = new List<Account>();
            if(userEmailList.Any())
            {
                foreach(var email in userEmailList)
                {
                    accountList.Add(_repository.account.GetByCondition(entity=>entity.Email.Equals(email),false).First());
                }
                if(accountList.Any())
                {
                    foreach(var account in accountList)
                    {
                        account.isVerified = true;
                        _repository.account.Update(account);
                        _repository.Save();
                    }
                    return true;
                }
            }
            return false;
        }
        public async Task<IEnumerable<Account>> GetVerifierAccounts(string username)
        {
            try
            {
                var user = await _repository.account.FindByNameAsync(username, false);
                return  _repository.account.GetByCondition(entity => entity.VerifiedBy.Equals(user.Id), false).ToList();
            }
            catch { throw; }
        }
    }
}
