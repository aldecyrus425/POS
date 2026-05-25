using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class Sales
    {
        public int SaleId { get; private set; }
        public string SaleNumber { get; private set; }
        public Branches Branches { get; private set; }
        public int BranchId { get; private set; }
        public Customers Customers { get; private set; }
        public int CustomersId { get; private set; }
        public Users Users { get; private set; }
        public int CashierId { get; private set; }
        public decimal Subtotal { get; private set; }
        public decimal DiscountAmount { get; private set; }
        public decimal TaxAmount { get; private set; }
        public decimal TotalAmount { get; private set; }
        public string Status { get; private set; } //COMPLETED, VOIDED, REFUNDED
        public string? Notes { get; private set; }
        public DateTime SoldAt { get; private set; }
        public DateTime? VoidedAt { get; private set; }
        public int? VoidedBy { get; private set; }

    }
}
