using Microsoft.EntityFrameworkCore;
using POS.Application.Interfaces.Repository;
using POS.Domain.Entities;
using POS.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Infrastructure.Repository
{
    public class PurchaseOrderRepository : IPurchaseOrdersRepository
    {

        private readonly ApplicationDBContext _context;

        public PurchaseOrderRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreatePurchaseOrderAsync(PurchaseOrders purchaseOrder)
        {
            await _context.PurchaseOrders.AddAsync(purchaseOrder);
        }

        public async Task<PurchaseOrders?> GetPurchaseOrderByIdAsync(int purchaseOrderId)
        {
            return await _context.PurchaseOrders.FirstOrDefaultAsync(p => p.PurchaseOrderID == purchaseOrderId);
        }
    }
    }

}

