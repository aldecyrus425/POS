using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class Branches
    {
        public int BranchId { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string ContactNumber { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
    }
}
