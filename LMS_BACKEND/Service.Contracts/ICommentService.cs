using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICommentService
    {
        Task UpdateComment(UpdateCommentRequestModel model, Guid Id);
        //Task<PagedList<CommentResponseModel>> GetPagedComment(Guid taskId, CommentParameters param);
        Task<PagedList<CommentResponseModel>> GetPagedComment(Guid taskId, CommentParameters param);
        Task<CommentResponseModel> CreateComment(CreateCommentRequestModel model, string userid, Guid taskId);
        Task<CommentResponseModel> GetCommentById(Guid id);
    }
}
