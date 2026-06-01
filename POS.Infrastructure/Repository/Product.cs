using Microsoft.EntityFrameworkCore;
using POS.Application.Interfaces.Repositories;
using POS.Domain.Entities;
using POS.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Infrastructure.Repository
{
    public class Product : IProductRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public async Task<bool> BarCodeExistsAsync(string barCode)
        {
            var exists = await _dbContext.Product.FirstOrDefaultAsync(p => p.Barcode == barCode);
            if (exists == null) return false;

            return true;

        }

        public async Task<Products> CreateProductAsync(Products product)
        {
            await _dbContext.Product.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _dbContext.Product.FirstOrDefaultAsync(p => p.ProductId == id);
            if (product == null) return false;

            _dbContext.Remove(product);
            return true;

        }

        public async Task<IEnumerable<Products>> GetAllProductsAsync()
        {
            return await _dbContext.Product
                .Where(p => !p.IsDeleted)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Products?> GetByBarCodeAsync(string barCode)
        {
            return await _dbContext.Product.FirstOrDefaultAsync(p => p.Barcode == barCode);
        }

        public async Task<Products?> GetProductByIdAsync(int id)
        {
            return await _dbContext.Product.FirstOrDefaultAsync(p => p.ProductId == id);
            
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
