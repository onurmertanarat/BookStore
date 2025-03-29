using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace Tests.TestSetup
{
    public class CommonTestFixture
    {
        public BookStoreDBContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<BookStoreDBContext>()
            .UseInMemoryDatabase(databaseName: "BookStoreTestDb").Options;
            Context = new BookStoreDBContext(options: options);
            Context.Database.EnsureCreated();

            Context.AddGenres();
            Context.AddAuthors();
            Context.AddBooks();

            Context.SaveChanges();

            Mapper = new MapperConfiguration(config => { config.AddProfile<MappingProfile>(); }).CreateMapper();

        }
    }
}
