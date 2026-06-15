using Microsoft.EntityFrameworkCore;
using POS.Application.Interfaces.Repository;
using POS.Domain.Entities;
using POS.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;

        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(Products product)
        {
            await _context.Product.AddAsync(product);
        }

        public async Task<Products?> GetProductByIDAsync(int id)
        {
            return await _context.Product.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
