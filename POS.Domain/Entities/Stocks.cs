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
    }
}
