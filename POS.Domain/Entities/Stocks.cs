using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class Stocks
    {
        public int StockId { get; private set; }
        public Products Products { get; private set; }
        public int ProductId { get; private set; }
        public Branches Branches { get; private set; }
        public int BranchesId { get; private set; }
        public decimal QuantityOnHand { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        protected Stocks() { }

        public Stocks(int productId, int branchId, decimal quantityOnHand)
        {
            if (productId < 0) throw new ArgumentOutOfRangeException("Invalid Product ID");

            if (branchId < 0) throw new ArgumentOutOfRangeException("Invalid Product ID");

            if (quantityOnHand < 0) throw new ArgumentOutOfRangeException("Quantity must not be negative");

            ProductId = productId;
            BranchesId = branchId;
            QuantityOnHand = quantityOnHand;
        }

        public void stockIn(int Quantity)
        {
            if (Quantity <= 0)
                throw new ArgumentException();

            QuantityOnHand += Quantity;
        }
    }
}
