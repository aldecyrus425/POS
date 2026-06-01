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

        protected Products() { }

        public Products(string barcode, string sku, string name, string description, int categoryId, int unitId, decimal costPrice, decimal sellingPrice, int reorderLevel, bool isTrackInventory, bool isActive, string imageUrl = null)
        {
            if (string.IsNullOrWhiteSpace(barcode))
                throw new ArgumentException("Barcode is required.", nameof(barcode));

            if (barcode.Length > 50)
                throw new ArgumentException("Barcode must not exceed 50 characters.", nameof(barcode));

            if (string.IsNullOrWhiteSpace(sku))
                throw new ArgumentException("SKU is required.", nameof(sku));

            if (sku.Length > 50)
                throw new ArgumentException("SKU must not exceed 50 characters.", nameof(sku));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name is required.", nameof(name));

            if (name.Length > 100)
                throw new ArgumentException("Product name must not exceed 100 characters.", nameof(name));

            if (!string.IsNullOrEmpty(description) && description.Length > 500)
                throw new ArgumentException("Description must not exceed 500 characters.", nameof(description));

            if (!string.IsNullOrEmpty(imageUrl) && imageUrl.Length > 255)
                throw new ArgumentException("Image URL must not exceed 255 characters.", nameof(imageUrl));

            if (categoryId <= 0)
                throw new ArgumentException("A valid Category is required.", nameof(categoryId));

            if (unitId <= 0)
                throw new ArgumentException("A valid Unit is required.", nameof(unitId));

            if (costPrice < 0)
                throw new ArgumentException("Cost price must not be negative.", nameof(costPrice));

            if (sellingPrice < 0)
                throw new ArgumentException("Selling price must not be negative.", nameof(sellingPrice));

            if (sellingPrice < costPrice)
                throw new ArgumentException("Selling price must not be lower than cost price.", nameof(sellingPrice));

            if (reorderLevel < 0)
                throw new ArgumentException("Reorder level must not be negative.", nameof(reorderLevel));

            this.Barcode = barcode.Trim();
            this.SKU = sku.Trim().ToUpper();
            this.Name = name.Trim();
            this.Description = description?.Trim();
            this.CategoryId = categoryId;
            this.UnitId = unitId;
            this.CostPrice = costPrice;
            this.SellingPrice = sellingPrice;
            this.ReorderLevel = reorderLevel;
            this.IsTrackInventory = isTrackInventory;
            this.IsActive = isActive;
            this.ImageUrl = imageUrl?.Trim();
            this.CreatedAt = DateTime.Now;
            this.IsDeleted = false;
        }

        public void DeleteProduct()
        {
            if (!IsActive)
                return;

            IsActive = false;
            IsDeleted = true;
            DeletedAt = DateTime.Now;
        }

        public void ReactivateProduct()
        {
            if (IsActive) 
                return;

            IsActive = true;
            IsDeleted = false;
            DeletedAt = null;
        }
    }
}
