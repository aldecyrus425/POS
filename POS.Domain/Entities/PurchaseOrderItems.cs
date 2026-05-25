using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class PurchaseOrderItems
    {
        public int PurchaseOrderItemsId { get; private set; }
        public PurchaseOrders PurchaseOrders { get; private set; }
        public int PurchaseOrderId { get; private set; }

        public Products Products { get; private set; }
        public int ProductId { get; private set; }

        public decimal Quantity { get; private set; }
        public decimal CostPrice { get; private set; }
        public decimal Total { get; private set; }

    }
}
