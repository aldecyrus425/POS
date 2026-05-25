using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class SalesReturnItems
    {
        public int SalesReturnItemId { get; private set; }
        public SalesReturns SalesReturns { get; private set; }
        public int SaleReturnId { get; private set; }
        public Products Products { get; private set; }
        public int ProductId { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal RefundAmount { get; private set; }

    }
}
