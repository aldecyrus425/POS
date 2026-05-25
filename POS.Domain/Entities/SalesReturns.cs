using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class SalesReturns
    {
        public int SalesReturnId { get; private set; }
        public Sales Sales { get; private set; }
        public int SaleId { get; private set; }
        public Users Users { get; private set; }
        public int ProcessedBy { get; private set; }
        public string Reason { get; private set; }
        public decimal TotalRefundAmount { get; private set; }
        public DateTime ReturnAt { get; private set; }
    }
}
