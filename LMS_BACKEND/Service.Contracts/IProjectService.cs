using Entities.Models;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;

namespace Service.Contracts
{
    public interface IProjectService
    {
        IEnumerable<ProjectResponseModel> GetProjects(string userId);
        Task<IEnumerable<Project>> GetAllProjects();
        IEnumerable<ProjectResponseModel> GetOnGoingProjects(string userId);
        Task CreatNewProject(CreateProjectRequestModel model);
        Task UpdateProject(Guid projectId, UpdateProjectRequestModel model);
        Task<GetFolderContentResponseModel> GetProjectResources(Guid ProjectID);
    }
}
