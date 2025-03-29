using FluentAssertions;
using WebApi.BookOperation.UpdateBook;

namespace Tests.Application.BookOperation.Command.UpdateBook
{
    public class UpdateBookCommandValidatorTests
    {
        [Theory]
        [InlineData(0, "", 0)]
        [InlineData(-5, "Valid Title", 1)]
        [InlineData(1, "", 1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(int bookId, string title, int genreId)
        {
            var cmd = new UpdateBookCommand(null);
            cmd.BookId = bookId;
            cmd.Model = new UpdateBookModel { Title = title, GenreId = genreId };

            var validator = new UpdateBookCommandValidator();

            var result = validator.Validate(cmd);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotReturnError()
        {
            var cmd = new UpdateBookCommand(null);
            cmd.BookId = 1;
            cmd.Model = new UpdateBookModel { Title = "Valid Title", GenreId = 1 };

            var validator = new UpdateBookCommandValidator();

            var result = validator.Validate(cmd);

            result.Errors.Count.Should().Be(0);
        }
    }
}
