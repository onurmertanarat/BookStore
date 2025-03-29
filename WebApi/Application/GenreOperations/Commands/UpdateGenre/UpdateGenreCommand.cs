using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        private IBookStoreDbContext _context;
        public UpdateGenreModel Model { get; set; }

        public UpdateGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Hande()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId) ?? throw new InvalidOperationException("Kitap türü bulunamadı!");

            if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
                throw new InvalidOperationException("Ayni isimli kitap türü zaten mevcut!");

            genre.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name;
            genre.IsActive = Model.IsActive;

            _context.SaveChanges();
        }
    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
