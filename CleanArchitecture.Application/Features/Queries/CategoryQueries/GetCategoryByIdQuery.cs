using AutoMapper;
using CleanArchitecture.Application.Features.Dtos.Responses.CategoryResponses;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery : IRequest<CategoryReadResponseDto>
    {
        public int Id { get; set; }
    }
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryReadResponseDto>
    {
        private readonly IGenericRepo<Category> _repo;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IGenericRepo<Category> repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<CategoryReadResponseDto> Handle(
            GetCategoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            var category = await _repo.GetByIdAsync(request.Id);
            if (category == null)
            {
                return null;
            }
            //var categoryDto = new CategoryReadResponseDto
            //{
            //    Id = category.Id,
            //    NameAr = category.NameAr,
            //    NameEn = category.NameEn,
            //    DescriptionAr = category.DescriptionAr,
            //    DescriptionEn = category.DescriptionEn,
            //    IsArchived = category.IsArchived
            //};
            var categoryDto = _mapper.Map<CategoryReadResponseDto>(category);
            return categoryDto;
        }
    }
}
