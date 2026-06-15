using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.Interfaces.Repository
{
    public interface IPurchaseOrdersRepository
    {
        Task CreatePurchaseOrderAsync(PurchaseOrders purchaseOrder);
        Task<PurchaseOrders?> GetPurchaseOrderByIdAsync(int purchaseOrderId);
    }
}
