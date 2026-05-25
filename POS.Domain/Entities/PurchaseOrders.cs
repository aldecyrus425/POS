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
        public decimal TotalAmount { get; private set; }
        public DateTime OrderAt {  get; private set; }
        public DateTime? ReceivedAt { get; private set; }
        public Users Users { get; private set; }
        public int CreatedBy { get; private set; }
    }
}
