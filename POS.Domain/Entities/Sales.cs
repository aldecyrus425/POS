using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        public int? CustomersId { get; private set; }
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

        protected Sales() { }

        public static Sales CreateSale(string saleNumber, int branchId, int? customerId, int cashierId, decimal subtotal, decimal discountAmount, decimal taxRate, string notes)
        {
            if (string.IsNullOrWhiteSpace(saleNumber))
                throw new ArgumentException("Sale number is required.");

            if (branchId <= 0)
                throw new ArgumentException("Invalid branch.");

            if (cashierId <= 0)
                throw new ArgumentException("Invalid cashier.");

            if (subtotal <= 0)
                throw new ArgumentException("Subtotal must be greater than zero.");

            if (discountAmount < 0)
                throw new ArgumentException("Discount amount cannot be negative.");

            if (discountAmount > subtotal)
                throw new ArgumentException("Discount cannot exceed subtotal.");

            if (taxRate < 0)
                throw new ArgumentException("Tax rate cannot be negative.");

            decimal taxableAmount = subtotal - discountAmount;
            decimal taxAmount = taxableAmount * taxRate;
            decimal totalAmount = taxableAmount + taxAmount;

            return new Sales
            {
                SaleNumber = saleNumber,
                BranchId = branchId,
                CustomersId = customerId,
                CashierId = cashierId,
                Subtotal = subtotal,
                DiscountAmount = discountAmount,
                TaxAmount = taxAmount,
                TotalAmount = totalAmount,
                Status = "COMPLETED",
                Notes = notes,
                SoldAt = DateTime.UtcNow
            };
        }
    }
}
