using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class StockMovements
    {
        public int StockMovementId { get; private set; }
        public Products Products { get; private set; }
        public int ProductId { get; private set; }
        public Branches Branches { get; private set; }
        public int BranchId { get; private set; }
        public string MovementType { get; private set; } // STOCK_IN, SALE, ADJUSTMENT, RETURN, VOID
        public decimal Quantity { get; private set; }
        public string ReferenceType { get; private set; }
        public int ReferenceId { get; private set; }
        public decimal PreviousStock { get; private set; }
        public decimal NewStock { get; private set; }
        public string? Remarks { get; private set; }
        public Users Users { get; private set; }
        public int CreatedBy { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
