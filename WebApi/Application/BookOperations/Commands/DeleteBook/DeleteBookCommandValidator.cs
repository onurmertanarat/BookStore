using FluentValidation;

namespace WebApi.BookOperation.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(cmd => cmd.BookId).GreaterThan(0);
        }
    }
}
