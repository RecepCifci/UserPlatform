using AutoMapper;
using UserPlatform.Application.Dtos;
using UserPlatform.Domain.Entities;

namespace UserPlatform.Application.Mapping;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Activity, ActivityDto>().ReverseMap();
    }
}
