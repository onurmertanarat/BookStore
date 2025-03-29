using WebApi.DBOperations;
using WebApi.Entities;

namespace Tests.TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDBContext context)
        {
            context.Authors.AddRange(
                    new Author { Name = "Eric", Surname = "Ries", BirthDate = new DateTime(1978, 09, 22) },
                    new Author { Name = "Charlotte", Surname = "Perkins", BirthDate = new DateTime(1860, 07, 03) },
                    new Author { Name = "Frank", Surname = "Herbert", BirthDate = new DateTime(1920, 10, 08) }
                );
        }
    }
}
