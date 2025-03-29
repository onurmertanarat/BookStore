using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.BookOperation.CreateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using static WebApi.BookOperation.CreateBook.CreateBookCommand;

namespace Tests.Application.BookOperation.Command.CreateBook
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistsBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // arrange => hazirlik
            var book = new Book() { Title = "Test_WhenAlreadyExistsBookTitleIsGiven_InvalidOperationException_ShouldBeReturn", PageCount = 100, PublishedDate = new DateTime(1990, 01, 10), GenreId = 1, AuthorId = 1 };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand cmd = new CreateBookCommand(_context, _mapper);
            cmd.Model = new CreateBookModel() { Title = "Test_WhenAlreadyExistsBookTitleIsGiven_InvalidOperationException_ShouldBeReturn" };

            // act => calistirma
            // assert => dogrulama
            FluentActions
                .Invoking(() => cmd.Handle())
                .Should().Throw<InvalidOperationException>()
                .WithMessage("Kitap zaten mevcut!");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
            CreateBookCommand cmd = new CreateBookCommand(_context, _mapper);
            CreateBookModel model = new CreateBookModel() { Title = "Hobbits", PageCount = 1000, PublishedDate = DateTime.Now.Date.AddYears(-10), GenreId = 1, AuthorId = 1 };
            cmd.Model = model;

            FluentActions.Invoking(() => cmd.Handle()).Invoke();

            var book = _context.Books.SingleOrDefault(x => x.Title == model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.PublishedDate.Should().Be(model.PublishedDate);
            book.GenreId.Should().Be(model.GenreId);
            book.AuthorId.Should().Be(model.AuthorId);
        }
    }
}
