using AutoMapper;
using EvaluationBackend.DATA.DTOs.Home;
using EvaluationBackend.DATA.DTOs.Section;
using EvaluationBackend.DATA.DTOs.Sets;
using EvaluationBackend.DATA.DTOs.User;
using EvaluationBackend.Entities;


namespace EvaluationBackend.Helpers
{
    public class UserMappingProfile : Profile
  {
    public UserMappingProfile()
    {


      CreateMap<AppUser, UserDto>()
      .ForMember(r => r.Role, src => src.MapFrom(src => src.Role));
      CreateMap<RegisterForm, AppUser>()
      .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

      CreateMap<Section,SectionDto>();
      CreateMap<SectionForm,Section>();
      CreateMap<SectionUpdate,Section>()
      .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

      CreateMap<Set,SetsDto>();
      CreateMap<SetsForm,Set>();
      CreateMap<SetsUpdate,Set>()
      .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));




      // CreateMap<Vehicle,VehicleDTO>();
      // CreateMap<VehicleForm, Vehicle>();
      // CreateMap<VehicleUpdate, Vehicle>()
      // .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


      






    }
  }
}