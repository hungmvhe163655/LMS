using Amazon.Auth.AccessControlPolicy;
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
            CreateMap<CreateNewsRequestModel, News>().ReverseMap();
            CreateMap<UpdateNewsRequestModel, News>().ReverseMap();
            CreateMap<NewsReponseModel, News>().ReverseMap();
            CreateMap<AccountVerifyUpdateDTO, Account>().ReverseMap();
            CreateMap<Files, FileUploadRequestModel>().ReverseMap();
            CreateMap<Files, FileResponseModel>()
                .ForMember(dest => dest.FolderPath, otp => otp.Ignore()).ReverseMap();
            CreateMap<Files, FileEditRequestModel>().ReverseMap();
            CreateMap<Account, AccountReturnModel>()
                .ForMember(dest => dest.Id, op => op.MapFrom(src => src.Id))
                .ForMember(dest => dest.PhoneNumber, op => op.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.UserName, op => op.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, op => op.MapFrom(src => src.Email))
                .ForMember(dest => dest.Gender, op => op.MapFrom(src => src.Gender ? "Male" : "Female"))
                .ForMember(dest => dest.IsBanned, op => op.MapFrom(src => src.IsBanned))
                .ForMember(dest => dest.IsDeleted, op => op.MapFrom(src => src.IsDeleted))
                .ReverseMap();
            CreateMap<Device, DeviceReturnModel>().ReverseMap();
            CreateMap<Schedule, ScheduleRequestModel>()
                .ReverseMap();
            CreateMap<Schedule, ScheduleResponseModel>()
                .ForMember(dest => dest.Account, op => op.MapFrom(src => src.Account))
                .ForMember(dest => dest.Device, op => op.MapFrom(src => src.Device));
            CreateMap<Schedule, ScheduleCreateRequestModel>().ReverseMap();

        }
    }
}

