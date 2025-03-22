using System;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.Surname).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.BirthDate).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}
