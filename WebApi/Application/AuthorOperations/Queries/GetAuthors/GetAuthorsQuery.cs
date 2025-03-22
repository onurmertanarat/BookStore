using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(BookStoreDBContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public List<GetAuthorsModel> Handle()
        {
            var authors = _dbContext.Authors.Include(x => x.Books).ThenInclude(b => b.Author).ToList();
            List<GetAuthorsModel> vm = _mapper.Map<List<GetAuthorsModel>>(authors);
            return vm;
        }
    }

    public class GetAuthorsModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public List<BookModel> Books { get; set; }
    }

    public class BookModel
    {
        public string Title { get; set; }
    }
}
