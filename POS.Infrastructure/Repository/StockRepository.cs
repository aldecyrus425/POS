using Microsoft.EntityFrameworkCore;
using POS.Application.Interfaces.Repository;
using POS.Domain.Entities;
using POS.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Infrastructure.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task AddStocksAsync(Stocks stock)
        {
            await _context.Stock.AddAsync(stock);

        }

        public async Task<decimal> GetByProductAndBranchAsync(int productId, int branchId)
        {
            return await _context.Stock
                .Where(s => s.ProductId == productId && s.BranchesId == branchId)
                .Select(s => s.QuantityOnHand)
                .FirstOrDefaultAsync();
        }
    }
}
