using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> GetAllProductsAsync();
        Task<Products?> GetProductByIdAsync(int id);
        Task<Products?> GetByBarCodeAsync(string barCode);
        Task<bool> BarCodeExistsAsync(string barCode);
        Task<Products> CreateProductAsync(Products products);
        Task<bool> DeleteProductAsync(int id);
        Task SaveChangesAsync();

    }
}
