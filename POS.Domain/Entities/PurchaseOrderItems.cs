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

        protected PurchaseOrderItems() { }

        public PurchaseOrderItems(int purchaseOrderId, int productId, decimal quantity, decimal costPrice)
        {
            if (purchaseOrderId <= 0)
                throw new ArgumentException("Purchase Order ID must be greater than zero.", nameof(purchaseOrderId));

            if (productId <= 0)
                throw new ArgumentException("Product ID must be greater than zero.", nameof(productId));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

            if (costPrice < 0)
                throw new ArgumentException("Cost price cannot be negative.", nameof(costPrice));

            PurchaseOrderId = purchaseOrderId;
            ProductId = productId;
            Quantity = quantity;
            CostPrice = costPrice;
            Total = quantity * costPrice;
        }

    }
}
