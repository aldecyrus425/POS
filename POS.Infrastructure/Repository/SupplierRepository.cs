using Microsoft.EntityFrameworkCore;
using POS.Application.Interfaces.Repository;
using POS.Domain.Entities;
using POS.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Infrastructure.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public SupplierRepository(ApplicationDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task CreateSupplierAsync(Supplier supplier)
        {
            await _dbContext.Suppliers.AddAsync(supplier);
        }

        public async Task<Supplier?> GetSupplierAsync(int supplierId)
        {
            return await _dbContext.Suppliers.FirstOrDefaultAsync(s => s.SupplierId == supplierId);
        }
    }
}
