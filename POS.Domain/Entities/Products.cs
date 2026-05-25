using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class Products
    {
        public int ProductId { get; private set; }
        public string Barcode { get; private set; }
        public string SKU { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Categories Categories { get; private set; }
        public int CategoryId { get; private set; }
        public Units Units { get; private set; }
        public int UnitId { get; private set; }
        public decimal CostPrice { get; private set; }
        public decimal SellingPrice { get; private set; }
        public int ReorderLevel { get; private set; }
        public bool IsTrackInventory { get; private set; }
        public bool IsActive { get; private set; }
        public string ImageUrl { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public bool IsDeleted { get; private set; }
    }
}
