using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.BookOperation.CreateBook;
using WebApi.DBOperations;

namespace Tests.Application.BookOperation.Command.CreateBook
{
    public class CreateBookCommandValidatorTests
    {
        [Theory]
        [InlineData("Lord of The Rings", 0, 0, 0)]
        [InlineData("Lord of The Rings", 0, 1, 1)]
        [InlineData("", 0, 0, 0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId, int authorId)
        {
            // arrange
            CreateBookCommand cmd = new CreateBookCommand(null, null);
            cmd.Model = new CreateBookCommand.CreateBookModel() { Title = title, PageCount = pageCount, PublishedDate = DateTime.Now.Date.AddYears(-1), GenreId = genreId, AuthorId = authorId };

            // act
            CreateBookCommandValidator valid = new CreateBookCommandValidator();
            var result = valid.Validate(cmd);

            // assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            CreateBookCommand cmd = new CreateBookCommand(null, null);
            cmd.Model = new CreateBookCommand.CreateBookModel() { Title = "Lord Of The Rings", PageCount = 1000, GenreId = 1, AuthorId = 1, PublishedDate = DateTime.Now.Date };

            CreateBookCommandValidator valid = new CreateBookCommandValidator();
            var result = valid.Validate(cmd);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateBookCommand cmd = new CreateBookCommand(null, null);
            cmd.Model = new CreateBookCommand.CreateBookModel() { Title = "Lord Of The Rings", PageCount = 1000, GenreId = 1, AuthorId = 1, PublishedDate = DateTime.Now.Date.AddYears(-2) };

            CreateBookCommandValidator valid = new CreateBookCommandValidator();
            var result = valid.Validate(cmd);

            result.Errors.Count.Should().Be(0);
        }
    }
}
