using DRDLab7RelatedData1.Models.Entities;
using System;

namespace DRDLab7RelatedData1.Services
{
    public interface IShelfRepository
    {
        Task<ICollection<Book>> ReadAllAsync();

        Task<Book?> ReadAsync(int id);

        Task<Book> CreateAsync(Book book);

        Task<Author> CreateAuthorAsync(int bookId, Author author);

        Task UpdateAuthorAsync(int bookId, Author author);

        Task DeleteAuthorAsync(int bookId, int authorId);
    }
}
