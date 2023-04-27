using FinalProject_AdvancedWeb.Models.Entities;
using Microsoft.EntityFrameworkCore;
using FinalProject_AdvancedWeb.Services;

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
            return await _app.Shelf
             .Include(a => a.Products)
             .ToListAsync();
            
        }

        public async Task<Shelf> CreateAsync(Shelf shelf)
        {
            await _app.Shelf.AddAsync(shelf);
            await _app.SaveChangesAsync();
            return shelf;
        }

        public async Task<Shelf?> ReadAsync(int id)
        {
            var book = await _app.Shelf.FindAsync(id);
            if (book != null)
            {
                _app.Entry(book)
                .Collection(a => a.Products)
                .Load();
            }
            return book;
        }

        public async Task<Product> CreateAuthorAsync(int shelfId, Product product)
        {
            var shelf = await _app.Shelf.FindAsync(shelfId);
            if (shelf != null)
            {
                shelf.Products.Add(product);
                product.Shelf = shelf;
                await _app.SaveChangesAsync();
            }

            return product;
        }

        public async Task UpdateProductAsync(int shelfId, Product updatedProduct)
        {
            var shelf = await ReadAsync(shelfId);
            if (shelf != null)
            {
                var productToUpdate = shelf.Products.FirstOrDefault(a => a.Id == updatedProduct.Id);
                if (productToUpdate != null)
                {
                    productToUpdate.ProductName = updatedProduct.ProductName;
                    productToUpdate.Quantity = updatedProduct.Quantity;
                    await _app.SaveChangesAsync();
                }
            }


        }

        public async Task DeleteProductAsync(int shelfId, int productId)
        {
            var shelf = await ReadAsync(shelfId);
            if (shelf != null)
            {
                var authorToDelete = shelf.Products.FirstOrDefault(a => a.Id == productId);
                if (authorToDelete != null)
                {
                    shelf.Products.Remove(authorToDelete);
                    await _app.SaveChangesAsync();
                }
            }
        }
    }
}
