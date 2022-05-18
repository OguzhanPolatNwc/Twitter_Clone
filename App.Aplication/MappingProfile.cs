using App.Application.Dtos;
using App.Infrastructure.Data;
using AutoMapper;

namespace App.Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //CreateMap<Category, CategoryDto>().ReverseMap();

        CreateMap<UserDto, User>();
    }
}