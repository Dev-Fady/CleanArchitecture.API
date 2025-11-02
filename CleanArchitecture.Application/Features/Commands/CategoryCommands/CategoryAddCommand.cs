using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Commands.CategoryCommands
{
    public class CategoryAddCommand : IRequest<bool>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
    }
    public class CategoryAddCommandHandler : IRequestHandler<CategoryAddCommand, bool>
    {
        private readonly IGenericRepo<Category> _repo;
        private readonly IMapper _mapper;

        public CategoryAddCommandHandler(
            IGenericRepo<Category> repo,
            IMapper mapper
            )
        {
            _repo = repo;
            _mapper = mapper;
        }
        public Task<bool> Handle(CategoryAddCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            var result = _repo.AddAsync(category);
            return result;
        }
    }
}
