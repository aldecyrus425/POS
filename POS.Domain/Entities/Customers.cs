using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class Customers
    {
        public int CustomerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ContactNumber { get; private set; }
        public string Address { get; private set; }
        public int LoyaltyPoints { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
