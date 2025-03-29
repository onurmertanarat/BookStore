using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetails
{
    public class GetAuthorDetailsQuery
    {
        public int AuthorId { get; set; }

        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAuthorDetailsQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GetAuthorDetailsModel Handle()
        {
            var author = _dbContext.Authors.FirstOrDefault(x => x.Id == AuthorId) ?? throw new InvalidOperationException("Yazar bulunamadı!");

            GetAuthorDetailsModel vm = _mapper.Map<GetAuthorDetailsModel>(author);

            return vm;
        }
    }

    public class GetAuthorDetailsModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public string FullName
        {
            get
            {
                return $"{Name} {Surname}";
            }
        }
    }
}
