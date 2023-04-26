using DRDLab7RelatedData1.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelatedDataCreateRead.Services;

namespace DRDLab7RelatedData1.Services
{
    public class DbShelfRepostory : IShelfRepository
    {
        private readonly ApplicationDbContext _app;

        public DbShelfRepostory(ApplicationDbContext app)
        {
            _app = app;
        }

        public async Task<ICollection<Book>> ReadAllAsync()
        {
            return await _app.Book
             .Include(a => a.Authors)
             .ToListAsync();
            
        }

        public async Task<Book> CreateAsync(Book book)
        {
            await _app.Book.AddAsync(book);
            await _app.SaveChangesAsync();
            return book;
        }

        public async Task<Book?> ReadAsync(int id)
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

        public async Task<Author> CreateAuthorAsync(int bookId, Author author)
        {
            var book = await _app.Book.FindAsync(bookId);
            if (book != null)
            {
                book.Authors.Add(author);
                author.Book = book;
                await _app.SaveChangesAsync();
            }

            return author;
        }

        public async Task UpdateAuthorAsync(int bookId, Author UpdatedAuthor)
        {
            var book = await ReadAsync(bookId);
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

        public async Task DeleteAuthorAsync(int bookId, int authorId)
        {
            var book = await ReadAsync(bookId);
            if (book != null)
            {
                var authorToDelete = book.Authors.FirstOrDefault(a => a.Id == authorId);
                if (authorToDelete != null)
                {
                    book.Authors.Remove(authorToDelete);
                    await _app.SaveChangesAsync();
                }
            }
        }
    }
}
