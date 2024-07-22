using Entities.Models;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;

namespace Service.Contracts
{
    public interface IProjectService
    {
        IEnumerable<ProjectResponseModel> GetProjects(string userId);
        Task<IEnumerable<Project>> GetAllProjects();
        Task<(IEnumerable<ProjectResponseModel> projects, MetaData metaData)> GetOnGoingProjects(string userId, ProjectRequestParameters projetParameter, bool trackChange);
        Task<Guid> CreatNewProject(CreateProjectRequestModel model);
        Task UpdateProject(Guid projectId, UpdateProjectRequestModel model);
        Task<GetFolderContentResponseModel> GetProjectResources(Guid ProjectID);
        Task<IEnumerable<AccountRequestJoinResponseModel>> GetJoinRequest(Guid projectId);
        Task ValidateJoinRequest(IEnumerable<UpdateStudentJoinRequestModel> Listmodel, Guid id);
    }
}
