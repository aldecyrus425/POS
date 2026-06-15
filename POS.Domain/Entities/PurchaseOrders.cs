using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class PurchaseOrders
    {
        public int PurchaseOrderID { get; private set; }
        public Supplier Supplier { get; private set; }
        public int SupplierId { get; private set; }
        public Branches Branches { get; private set; }
        public int BranchId { get; private set; }
        public string PONumber { get; private set; }
        public string Status { get; private set; }
        public decimal? TotalAmount { get; private set; }
        public DateTime? OrderAt {  get; private set; }
        public DateTime? ReceivedAt { get; private set; }
        public Users Users { get; private set; }
        public int CreatedBy { get; private set; }

        protected PurchaseOrders() { }
        public PurchaseOrders(int supplierId, int branchId, string pONumber, string status, int createdBy)
        {
            if (supplierId <= 0)
                throw new ArgumentException("SupplierId must be greater than 0.", nameof(supplierId));

            if (branchId <= 0)
                throw new ArgumentException("BranchId must be greater than 0.", nameof(branchId));

            if (string.IsNullOrWhiteSpace(pONumber))
                throw new ArgumentException("PO Number is required.", nameof(pONumber));

            if (pONumber.Length > 50)
                throw new ArgumentException("PO Number cannot exceed 50 characters.", nameof(pONumber));

            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("Status is required.", nameof(status));

            if (status.Length > 20)
                throw new ArgumentException("Status cannot exceed 20 characters.", nameof(status));

            if (createdBy <= 0)
                throw new ArgumentException("CreatedBy must be greater than 0.", nameof(createdBy));

            SupplierId = supplierId;
            BranchId = branchId;
            PONumber = pONumber.Trim();
            Status = status.Trim();
            CreatedBy = createdBy;
        }
    }
}
