using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using MediatR;

namespace CleanArchitecture.Application.Features.Commands.CategoryCommands
{
    public class CategoryUpdateCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public string? DescriptionAr { get; set; }
        public string? DescriptionEn { get; set; }
    }
    public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, bool>
    {
        private readonly IGenericRepo<Category> _repo;
        private readonly IMapper _mapper;

        public CategoryUpdateCommandHandler(
            IGenericRepo<Category> repo,
            IMapper mapper
            )
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
        {
            var category = await _repo.GetByIdAsync(request.Id);
            if (category == null)
            {
                return false;
            }
            var CategoryEntity = _mapper.Map(request, category);
            var status = await _repo.UpdateAsync(CategoryEntity);
            return status;
        }
    }
}
