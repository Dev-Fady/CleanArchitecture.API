using CleanArchitecture.Application.Features.Commands.CategoryCommands;
using CleanArchitecture.Application.Features.Queries.CategoryQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var query = new GetCategoryByIdQuery { Id = Id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllAsync()
        //{
        //    var query = new GetCategoriesQuery();
        //    var result = await _mediator.Send(query);
        //    return Ok(result);
        //}

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] GetCategoriesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CategoryAddCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CategoryUpdateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> ArchiveAsync(int Id)
        {
            var command = new CategoryArchivedCommand { Id = Id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("{Id}")]
        public async Task<IActionResult> UnArchiveAsync(int Id)
        {
            var command = new CategoryUnArchivedCommand { Id = Id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
