using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class Payments
    {
        public int PaymentId { get; private set; }
        public Sales Sales { get; private set; }
        public int SaleId { get; private set; }
        public string PaymentMethod { get; private set; } //CASH, GCASH, MAYA, CARD
        public decimal Amount { get; private set; }
        public string ReferenceNumber { get; private set; }
        public DateTime PaidAt { get; private set; }
    }
}
