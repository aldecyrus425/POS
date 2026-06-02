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

        public async Task AddProduct(Products product)
        {
            await _context.Product.AddAsync(product);
        }
    }
}
