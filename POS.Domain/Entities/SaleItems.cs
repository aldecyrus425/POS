using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class SaleItems
    {
        public int SaleItemId { get; private set; }
        public Sales Sales { get; private set; }
        public int SaleId { get; private set; }
        public Products Products { get; private set; }
        public int ProductId { get; private set; }
        public string ProductNameSnapshot { get; private set; }
        public string BarcodeSnapshot { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal DiscountAmount { get; private set; }
        public decimal TotalAmount { get; private set; }
    }
}
