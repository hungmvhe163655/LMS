using AutoMapper;
using Contracts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using Shared.GlobalVariables;
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

        //public async Task<PagedList<CommentResponseModel>> GetPagedComment(Guid taskId, CommentParameters param)
        public async Task<(List<CommentResponseModel> Data, int? Cursor)> GetListComment(Guid taskId, CommentParameters param)
        {
            var hold2 = await _repository.Comment.GetCommentByTaskId2(taskId, param);

            //return PagedList<CommentResponseModel>.ToPagedList(_mapper.Map<IEnumerable<CommentResponseModel>>(await hold.ToListAsync()), param.PageNumber, param.PageSize);

            var end = hold2.Skip(param.Cursor ?? SCROLL_LIST.DEFAULT_TOP).Take(param.Take ?? SCROLL_LIST.TINY10).ToList();

            var taken = end.Count + (param.Cursor ?? SCROLL_LIST.DEFAULT_TOP);

            return (_mapper.Map<List<CommentResponseModel>>(end), hold2.Count > taken ? taken : null);

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
