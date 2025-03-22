using FluentValidation;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetails
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(q => q.GenreId).GreaterThan(0);
        }
    }
}
