using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MemberService: IMemberService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public MemberService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MemberResponseModel>> GetMembers(Guid projectId)
        {
            var hold = await _repository.member
                .GetByCondition(x => x.ProjectId.Equals(projectId), false)
                .Include(x => x.User)
                .ToListAsync();
            var memberDto = _mapper.Map<IEnumerable<MemberResponseModel>>(hold);
            return memberDto;
        }

        public async Task DeleteMember(Guid id, Guid projectId)
        {
            var hold = await _repository.member.GetByCondition(x => x.UserId.Equals(id) && x.ProjectId.Equals(projectId), true).FirstOrDefaultAsync();
            if (hold == null) throw new BadRequestException($"Can't found member with id {id} in project {projectId}");
            _repository.member.Delete(hold);
            await _repository.Save();
        }
    }
}
