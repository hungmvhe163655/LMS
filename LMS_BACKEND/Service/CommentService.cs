using AutoMapper;
using Contracts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CommentService : ICommentService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CommentService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedList<CommentResponseModel>> GetPagedComment(Guid taskId, RequestParameters param)
        {
            var hold = _repository.Comment.GetCommentByTaskId(taskId);

            return PagedList<CommentResponseModel>.ToPagedList(_mapper.Map<IEnumerable<CommentResponseModel>>(await hold.ToListAsync()), param.PageNumber, param.PageSize);
        }

        public async Task<CommentResponseModel> CreateComment(CreateCommentRequestModel model, string userid, Guid taskId)
        {
            var hold = _mapper.Map<Comment>(model);

            hold.Id = Guid.NewGuid();

            hold.CreatedBy = userid;

            hold.CreatedDate = DateTime.Now;

            hold.TaskId = taskId;

            await _repository.Comment.CreateComment(hold);

            await _repository.Save();

            return _mapper.Map<CommentResponseModel>(hold);
        }

        public async Task UpdateComment(UpdateCommentRequestModel model, Guid Id)
        {
            var hold = await _repository.Comment.GetCommentById(Id, true).FirstOrDefaultAsync();

            _mapper.Map(model, hold);

            await _repository.Save();
        }

        public async Task<CommentResponseModel> GetCommentById(Guid id)
        {
            return _mapper.Map<CommentResponseModel>(await _repository.Comment.GetCommentById(id, false).FirstOrDefaultAsync());
        }
    }
}
