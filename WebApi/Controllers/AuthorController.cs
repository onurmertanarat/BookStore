using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetails;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand cmd = new CreateAuthorCommand(_dbContext, _mapper);
            cmd.Model = newAuthor;

            CreateAuthorCommandValidator valid = new CreateAuthorCommandValidator();
            valid.ValidateAndThrow(cmd);

            cmd.Handle();

            return Ok("Yazar başarıyla eklendi.");
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_dbContext, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            GetAuthorDetailsModel result;

            GetAuthorDetailsQuery query = new GetAuthorDetailsQuery(_dbContext, _mapper);
            query.AuthorId = id;

            GetAuthorDetailsQueryValidator valid = new GetAuthorDetailsQueryValidator();
            valid.ValidateAndThrow(query);

            result = query.Handle();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updateAuthor)
        {
            UpdateAuthorCommand cmd = new UpdateAuthorCommand(_dbContext);

            cmd.AuthorId = id;
            cmd.Model = updateAuthor;

            UpdateAuthorCommandValidator valid = new UpdateAuthorCommandValidator();
            valid.ValidateAndThrow(cmd);

            cmd.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand cmd = new DeleteAuthorCommand(_dbContext);

            cmd.AuthorId = id;

            DeleteAuthorCommandValidator valid = new DeleteAuthorCommandValidator();
            valid.ValidateAndThrow(cmd);

            cmd.Handle();

            return Ok();
        }
    }
}
