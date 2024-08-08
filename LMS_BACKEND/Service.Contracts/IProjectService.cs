using Entities.Models;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;

namespace Service.Contracts
{
    public interface IProjectService
    {
        Task<(IEnumerable<ProjectResponseModel> projects, MetaData metaData)> GetProjects(string userId, ProjectRequestParameters projetParameter, bool trackChange);
        Task<(IEnumerable<ProjectResponseModel> projects, MetaData metaData)> GetAllProjects(ProjectRequestParameters projetParameter, bool trackChange);
        Task<int> CountProject(string type);
        Task<ProjectViewResponseModel> GetProjectById(Guid id);
        Task UpdateProject(ProjectUpdateRequestModel model, Guid id, string userID);
        Task<ProjectViewResponseModel> CreateNewProject(string userId, CreateProjectRequestModel model);
        Task<GetFolderContentResponseModel> GetProjectResources(Guid ProjectID);
        Task<IEnumerable<AccountRequestJoinResponseModel>> GetJoinRequest(Guid projectId);
        Task ValidateJoinRequest(IEnumerable<UpdateStudentJoinRequestModel> Listmodel, Guid id);
    }
}
