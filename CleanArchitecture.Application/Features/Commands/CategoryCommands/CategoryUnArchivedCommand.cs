using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using MediatR;

namespace CleanArchitecture.Application.Features.Commands.CategoryCommands
{
    public class CategoryUnArchivedCommand : IRequest<bool>
    {
        public int Id { get; set; }
       
    }
    public class CategoryUnArchivedCommandHandler : IRequestHandler<CategoryUnArchivedCommand, bool>
    {
        private readonly IGenericRepo<Category> _repo;
        private readonly IMapper _mapper;

        public CategoryUnArchivedCommandHandler(
            IGenericRepo<Category> repo,
            IMapper mapper
            )
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CategoryUnArchivedCommand request, CancellationToken cancellationToken)
        {
            var category = await _repo.GetByIdAsync(request.Id);
            if (category == null)
            {
                return false;
            }
            //var CategoryEntity = _mapper.Map(request, category);
            var status = await _repo.UnArchivedAsync(category);
            return status;
        }
    }
}
