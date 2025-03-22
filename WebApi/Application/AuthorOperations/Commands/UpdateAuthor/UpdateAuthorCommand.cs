using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public UpdateAuthorModel Model { get; set; }
        public int AuthorId { get; set; }

        private readonly BookStoreDBContext _dbContext;

        public UpdateAuthorCommand(BookStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId) ?? throw new InvalidOperationException("Yazar bulunamadı!");

            author.Name = string.IsNullOrWhiteSpace(Model.Name) ? Model.Name : author.Name;
            author.Surname = string.IsNullOrWhiteSpace(Model.Surname) ? Model.Surname : author.Surname;
            author.BirthDate = Model.BirthDate != default ? Model.BirthDate : author.BirthDate;

            _dbContext.SaveChanges();
        }
    }
    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
