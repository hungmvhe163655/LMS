using AutoMapper;
using Contracts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
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
        public async Task<Account> GetUserById(string id) => await _repository.account.GetByCondition(entity=>entity.Id.Equals(id), false).FirstAsync();
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
        public async Task<bool> UpdateAccountVerifyStatus(IEnumerable<string> UserIDList,string verifier)
        {
            List<Account> accountList = new List<Account>();
            if(UserIDList.Any())
            {
                foreach(var ID in UserIDList)
                {
                    accountList.Add(_repository.account.GetByCondition(entity=>entity.Id.Equals(ID),false).First());
                }
                if(accountList.Any())
                {
                    foreach(var account in accountList)
                    {
                        account.isVerified = true;
                        account.VerifiedBy = verifier;
                        _repository.account.Update(account);
                        _repository.Save();
                    }
                    return true;
                }
            }
            return false;
        }
        public async Task<IEnumerable<Account>> GetVerifierAccounts(string email)
        {
            try
            {
                var user = await _repository.account.GetByConditionAsync(entity=>entity.Email.Equals(email), false);
                var end = user.First();
                return  _repository.account.GetByCondition(entity => entity.VerifiedBy.Equals(end.Id), false).ToList();
            }
            catch { throw; }
        }
    }
}
