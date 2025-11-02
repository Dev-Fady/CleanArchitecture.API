using AutoMapper;
using CleanArchitecture.Application.Extentions;
using CleanArchitecture.Application.Features.Dtos;
using CleanArchitecture.Application.Features.Dtos.Responses.CategoryResponses;
using CleanArchitecture.Domain.Extentions;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Queries.CategoryQueries
{
    public enum CategorySortBy
    {
        NameAr=1,
        NameEn=2,
        DescriptionAr=3,
        DescriptionEn=4
    }
    public class GetCategoriesQuery : PaginateBaseParamter,
      IRequest<Response<PaginatedList<CategoryReadResponseDto>>>
    {
        public string? TextSeach { get; set; }
        public CategorySortBy? OrderBy { get; set; }
        public bool IsDescending { get; set; }
        public bool IsArchived { get; set; }


    }
    public class GetCategoriesQueryHandler :
        IRequestHandler<GetCategoriesQuery, Response<PaginatedList<CategoryReadResponseDto>>>
    {
        private readonly IGenericRepo<Category> _repo;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(IGenericRepo<Category> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Response<PaginatedList<CategoryReadResponseDto>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var query = _repo.GetAll()
                .WhereIf(request.IsArchived != null, a => a.IsArchived == request.IsArchived)
                .FilterText(request.TextSeach)
                .OrderGroupBy(new List<(bool condition, Expression<Func<Category, object>>)>
                {
                    (CategorySortBy.NameAr==request.OrderBy , x=>x.NameAr),
                    (CategorySortBy.NameEn==request.OrderBy , x=>x.NameEn),
                    (CategorySortBy.DescriptionAr==request.OrderBy , x=>x.DescriptionAr),
                    (CategorySortBy.DescriptionEn==request.OrderBy , x=>x.DescriptionEn),
                }, IsDescending: true)
                .Select(a => new CategoryReadResponseDto
                {
                    Id = a.Id,
                    IsArchived = a.IsArchived,
                    NameAr = a.NameAr,
                    NameEn = a.NameEn,
                    DescriptionAr = a.DescriptionAr,
                    DescriptionEn = a.DescriptionEn
                });
            
            var count = query.Count();
            var response = query.Paginate(request.PageNumber, request.PageSize);

            return new Response<PaginatedList<CategoryReadResponseDto>>
             (
                new PaginatedList<CategoryReadResponseDto>(response, count, request.PageNumber, request.PageSize)
             );
        }
    }
}
