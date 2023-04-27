﻿using FinalProject_AdvancedWeb.Models.Entities;
using System;

namespace FinalProject_AdvancedWeb.Services
{
    public interface IShelfRepository
    {
        Task<ICollection<Shelf>> ReadAllAsync();

        Task<Shelf?> ReadAsync(int id);

        Task<Shelf> CreateAsync(Shelf shelf);

        Task<Product> CreateAuthorAsync(int shelfId, Product product);

        Task UpdateProductAsync(int shelfId, Product updatedProduct);

        Task DeleteProductAsync(int shelfId, int productId);
    }
}
