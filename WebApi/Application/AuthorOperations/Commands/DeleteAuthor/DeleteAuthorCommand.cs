using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }

        private readonly IBookStoreDbContext _dbContext;

        public DeleteAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId) ?? throw new InvalidOperationException("Yazar bulunamadı!");

            var hasBooks = _dbContext.Books.Any(b => b.AuthorId == AuthorId);
            if (hasBooks)
                throw new InvalidOperationException("Yayımlanmış kitabı bulunan yazar silinemez!");

            _dbContext.Authors.Remove(author);

            _dbContext.SaveChanges();
        }
    }
}
