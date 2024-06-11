using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.RequestDTO;

namespace LMS_BACKEND_MAIN
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, StudentRegisterRequestModel>()
                   .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                   .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                   .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                   .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                   .ForMember(dest => dest.SupervisorID, opt => opt.Ignore()) 
                   .ForMember(dest => dest.Password, opt => opt.Ignore()); 
        }
    }
}
