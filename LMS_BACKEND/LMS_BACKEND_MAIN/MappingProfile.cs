using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;

namespace LMS_BACKEND_MAIN
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, RegisterRequestModel>()
                   .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                   .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                   .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                   .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                   .ForMember(dest => dest.VerifiedByUserID, opt => opt.MapFrom(src => src.VerifiedBy))
                   .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                   .ForMember(dest => dest.Password, opt => opt.Ignore());
            CreateMap<RegisterRequestModel, Account>()
                  .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                  .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                  .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                  .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                  .ForMember(dest => dest.VerifiedBy, opt => opt.MapFrom(src => src.VerifiedByUserID))
                  .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                  .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            CreateMap<CreateNewsRequestModel, News>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.NewsFiles, opt => opt.MapFrom(src =>
                    src.FileKey != null
                        ? src.FileKey.Select(fileKey => new NewsFile { FileKey = fileKey }).ToList()
                        : new List<NewsFile>()
                ))
                .ReverseMap();
            CreateMap<NewsFileRequestModel, NewsFile>().ReverseMap();
            CreateMap<UpdateNewsRequestModel, News>()
                .ForMember(dest => dest.NewsFiles, opt => opt.MapFrom(src =>
                    src.FileKey != null
                        ? src.FileKey.Select(fileKey => new NewsFile { FileKey = fileKey }).ToList()
                        : new List<NewsFile>()
                ))
                .ReverseMap();
            CreateMap<NewsReponseModel, News>()
                .ForPath(dest => dest.CreatedByNavigation.FullName, opt => opt.MapFrom(src => src.CreatedBy))
                .ReverseMap();
            CreateMap<AccountVerifyUpdateDTO, Account>().ReverseMap();
            CreateMap<Files, FileUploadRequestModel>().ReverseMap();
            CreateMap<Files, FileResponseModel>()
                .ForMember(dest => dest.FolderPath, otp => otp.Ignore()).ReverseMap();
            CreateMap<Files, FileEditRequestModel>().ReverseMap();
            CreateMap<Account, AccountDetailResponseModel>()
                .ForMember(dest => dest.RollNumber, opt => opt.Ignore())
                .ForMember(dest => dest.Major, opt => opt.Ignore())
                .ForMember(dest => dest.Specialized, opt => opt.Ignore())
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender ? "Male" : "Female"))
                .ReverseMap()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase)));
            CreateMap<StudentDetail, AccountDetailResponseModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.FullName, opt => opt.Ignore())
                .ForMember(dest => dest.Gender, opt => opt.Ignore())
                .ForMember(dest => dest.Role, opt => opt.Ignore())
                .ForMember(dest => dest.Email, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumber, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Account, AccountReturnModel>()
                .ForMember(dest => dest.Id, op => op.MapFrom(src => src.Id))
                .ForMember(dest => dest.PhoneNumber, op => op.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.UserName, op => op.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, op => op.MapFrom(src => src.Email))
                .ForMember(dest => dest.Gender, op => op.MapFrom(src => src.Gender ? "Male" : "Female"))
                .ForMember(dest => dest.IsBanned, op => op.MapFrom(src => src.IsBanned))
                .ForMember(dest => dest.IsDeleted, op => op.MapFrom(src => src.IsDeleted))
                .ForMember(dest => dest.IsVerified, op => op.MapFrom(src => src.IsVerified))
                .ReverseMap();
            CreateMap<Device, DeviceReturnModel>().ReverseMap();
            CreateMap<Schedule, ScheduleRequestModel>()
                .ReverseMap();
            CreateMap<Schedule, ScheduleResponseModel>()
                .ForMember(dest => dest.Account, op => op.MapFrom(src => src.Account))
                .ForMember(dest => dest.Device, op => op.MapFrom(src => src.Device));
            CreateMap<Schedule, ScheduleCreateRequestModel>().ReverseMap();
            CreateMap<Tasks, TaskHistory>()
                .ForMember(dest => dest.TaskGuid, op => op.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, op => op.Ignore())
                .ForMember(dest => dest.EditDate, op => op.Ignore())
                //.ForMember(dest => dest.AssignedToUser, op => op.MapFrom(src => src.AssignedToUser))
                ;
            CreateMap<TaskCreateRequestModel, Tasks>().ReverseMap();
            CreateMap<TaskUpdateRequestModel, Tasks>().ReverseMap();
            CreateMap<CreateTaskListRequestModel, TaskList>().ReverseMap();
            CreateMap<UpdateTaskListRequestModel, TaskList>().ReverseMap();
            CreateMap<Project, CreateProjectRequestModel>().ReverseMap();
            CreateMap<UpdateProjectRequestModel, Project>().ReverseMap();
            CreateMap<Project, ProjectResponseModel>()
                .ForMember(dest => dest.TaskUndone, op => op.Ignore())
                .ForMember(dest => dest.ListTaskUndone, op => op.Ignore())
                .ReverseMap();
            CreateMap<Account, MinorAccountReturnModel>();
            CreateMap<Tasks, TaskResponseModel>().ReverseMap();
            CreateMap<TaskList, TaskListResponseModel>()
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));
            CreateMap<Tasks, TasksViewResponseModel>()
               .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
               .ForMember(dest => dest.AssignedTo, opt => opt.MapFrom(src => src.AssignedTo))
               .ForMember(dest => dest.AssignedToUser, opt => opt.MapFrom(src => src.AssignedToUser != null ? src.AssignedToUser.FullName : "NotFound"))
               .ForMember(dest => dest.TaskStatus, opt => opt.MapFrom(src => src.TaskStatus))
               .ForMember(dest => dest.TaskListId, opt => opt.MapFrom(src => src.TaskListId))
               .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))
               .ReverseMap();
            CreateMap<Account, AccountNeedVerifyResponseModel>();
            CreateMap<MoveTaskRequestModel, Tasks>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TaskListId, opt => opt.MapFrom(src => src.TaskListId));
            CreateMap<Member, MemberResponseModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User != null ? src.User.FullName : "NotFound"))
                .ReverseMap();
            CreateMap<Folder, FolderBranchDisplayResponseModel>()
                .ForMember(c => c.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(c => c.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(c => c.Depth, opt => opt.Ignore());
            CreateMap<Account, AccountRequestJoinResponseModel>();
            CreateMap<Report, ReportResponseModel>()
                .ForMember(x => x.Schedules, opt => opt.MapFrom(src => src.Schedules));
            CreateMap<Notification, NotificationResponseModel>();
            CreateMap<Account, AccountManagementResponseModel>()
                .ForMember(x => x.Role, opt => opt.Ignore())
                .ForMember(x => x.Status, opt => opt.MapFrom(src => src.IsBanned ? "Banned" : src.IsVerified ? "Active" : "Unverified"))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Gender, op => op.MapFrom(src => src.Gender ? "Male" : "Female"));
            CreateMap<CreateNewsRequestModel, News>()
                .ForMember(dest => dest.NewsFiles, opt => opt.MapFrom(src =>
                    src.FileKey != null
                        ? src.FileKey.Select(fileKey => new NewsFile { FileKey = fileKey }).ToList()
                        : new List<NewsFile>()
                )).ReverseMap();
            CreateMap<Folder, FolderResponseModel>().ReverseMap();
            CreateMap<Device, CreateDeviceRequestModel>().ReverseMap();
            CreateMap<Device, UpdateDeviceRequestModel>().ReverseMap();

            CreateMap<Comment, CommentResponseModel>();

            CreateMap<CreateCommentRequestModel, Comment>();
        }
    }
}
