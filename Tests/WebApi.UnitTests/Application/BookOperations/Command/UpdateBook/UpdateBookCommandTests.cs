using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.BookOperation.UpdateBook;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Tests.Application.BookOperation.Command.UpdateBook
{
    public class UpdateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDBContext _context;
        public UpdateBookCommandTests(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.Context;
        }

        [Fact]
        public void WhenBookIdDoesNotExist_InvalidOperationException_ShouldBeThrown()
        {
            var cmd = new UpdateBookCommand(_context);
            cmd.BookId = 999;
            cmd.Model = new UpdateBookModel { Title = "New Title", GenreId = 1 };

            FluentActions
                .Invoking(() => cmd.Handle())
                .Should().Throw<InvalidOperationException>()
                .WithMessage("Kitap bulunamadı.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeUpdated()
        {
            var book = new Book { Title = "Old Title", PageCount = 150, PublishedDate = DateTime.Now.AddYears(-2), GenreId = 1, AuthorId = 1 };
            _context.Books.Add(book);
            _context.SaveChanges();

            var cmd = new UpdateBookCommand(_context);
            cmd.BookId = book.Id;
            cmd.Model = new UpdateBookModel { Title = "Updated Title", GenreId = 1 };

            FluentActions.Invoking(() => cmd.Handle()).Invoke();

            var updatedBook = _context.Books.SingleOrDefault(b => b.Id == book.Id);
            updatedBook.Should().NotBeNull();
            updatedBook.Title.Should().Be("Updated Title");
            updatedBook.GenreId.Should().Be(1);
        }
    }
}
