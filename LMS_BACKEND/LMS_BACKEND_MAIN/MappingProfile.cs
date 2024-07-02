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
                   .ForMember(dest => dest.Password, opt => opt.Ignore());
            CreateMap<RegisterRequestModel, Account>()
                  .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                  .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                  .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                  .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                  .ForMember(dest => dest.VerifiedBy, opt => opt.MapFrom(src => src.VerifiedByUserID))
                  .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            CreateMap<CreateNewsRequestModel, News>().ReverseMap();
            CreateMap<NewsReponseModel, News>().ReverseMap();
            CreateMap<AccountVerifyUpdateDTO, Account>().ReverseMap();
            CreateMap<Files, FileUploadRequestModel>().ReverseMap();
            CreateMap<Files, FileResponseModel>()
                .ForMember(dest => dest.FolderPath, otp => otp.Ignore()).ReverseMap();
            CreateMap<Files, FileEditRequestModel>().ReverseMap();
        }
    }
}

