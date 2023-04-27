using FinalProject_AdvancedWeb.Models.Entities;
using Microsoft.EntityFrameworkCore;
using RelatedDataCreateRead.Services;

namespace FinalProject_AdvancedWeb.Services
{
    public class DbShelfRepostory : IShelfRepository
    {
        private readonly ApplicationDbContext _app;

        public DbShelfRepostory(ApplicationDbContext app)
        {
            _app = app;
        }

        public async Task<ICollection<Shelf>> ReadAllAsync()
        {
            return await _app.Book
             .Include(a => a.Authors)
             .ToListAsync();
            
        }

        public async Task<Shelf> CreateAsync(Shelf shelf)
        {
            await _app.Book.AddAsync(shelf);
            await _app.SaveChangesAsync();
            return shelf;
        }

        public async Task<Shelf?> ReadAsync(int id)
        {
            var book = await _app.Book.FindAsync(id);
            if (book != null)
            {
                _app.Entry(book)
                .Collection(a => a.Authors)
                .Load();
            }
            return book;
        }

        public async Task<Product> CreateAuthorAsync(int shelfId, Product product)
        {
            var shelf = await _app.Book.FindAsync(shelfId);
            if (shelf != null)
            {
                shelf.Authors.Add(product);
                product.Shelf = shelf;
                await _app.SaveChangesAsync();
            }

            return product;
        }

        public async Task UpdateAuthorAsync(int shelfId, Author UpdatedAuthor)
        {
            var book = await ReadAsync(shelfId);
            if (book != null)
            {
                var authorToUpdate = book.Authors.FirstOrDefault(a => a.Id == UpdatedAuthor.Id);
                if (authorToUpdate != null)
                {
                    authorToUpdate.FirstName = UpdatedAuthor.FirstName;
                    authorToUpdate.LastName = UpdatedAuthor.LastName;
                    await _app.SaveChangesAsync();
                }
            }


        }

        public async Task DeleteAuthorAsync(int shelfId, int authorId)
        {
            var shelf = await ReadAsync(shelfId);
            if (shelf != null)
            {
                var authorToDelete = shelf.Authors.FirstOrDefault(a => a.Id == authorId);
                if (authorToDelete != null)
                {
                    shelf.Authors.Remove(authorToDelete);
                    await _app.SaveChangesAsync();
                }
            }
        }
    }
}
