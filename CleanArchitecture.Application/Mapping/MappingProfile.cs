using AutoMapper;
using CleanArchitecture.Application.Features.Commands.CategoryCommands;
using CleanArchitecture.Application.Features.Dtos.Responses.CategoryResponses;
using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category,CategoryReadResponseDto>().ReverseMap();
            CreateMap<Category,CategoryAddCommand>().ReverseMap();
            CreateMap<CategoryUpdateCommand, Category>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
