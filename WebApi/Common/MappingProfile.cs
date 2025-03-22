using AutoMapper;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetails;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.GenreOperations.Queries.GetGenreDetails;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.BookOperation.GetBookDetail;
using WebApi.BookOperation.GetBooks;
using WebApi.Entities;
using static WebApi.BookOperation.CreateBook.CreateBookCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
            .ForMember(d => d.Author, o => o.MapFrom(s => s.Author.Name + " " + s.Author.Surname));
            CreateMap<Book, BooksViewModel>()
            .ForMember(x => x.Genre, opt => opt.MapFrom(y => y.Genre.Name))
            .ForMember(d => d.Author, o => o.MapFrom(s => s.Author.Name + " " + s.Author.Surname));
            CreateMap<Book, BookModel>();

            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();

            CreateMap<CreateAuthorModel, Author>();
            CreateMap<Author, GetAuthorsModel>()
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.Date.ToString("dd.MM.yyyy")));
            CreateMap<Author, GetAuthorDetailsModel>()
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.Date.ToString("dd.MM.yyyy")));
        }
    }
}
