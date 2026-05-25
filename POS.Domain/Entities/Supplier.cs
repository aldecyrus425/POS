using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class Supplier
    {
        public int SupplierId { get; private set; }
        public string SupplierName { get; private set; }
        public string ContactNumber { get; private set; }
        public string Address { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; }
    }
}
