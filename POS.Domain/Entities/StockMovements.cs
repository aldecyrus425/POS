using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class StockMovements
    {
        public int StockMovementId { get; private set; }
        public Products Products { get; private set; }
        public int ProductId { get; private set; }
        public Branches Branches { get; private set; }
        public int BranchId { get; private set; }
        public string MovementType { get; private set; } // STOCK_IN, SALE, ADJUSTMENT, RETURN, VOID
        public decimal Quantity { get; private set; }
        public string ReferenceType { get; private set; }
        public string ReferenceId { get; private set; }
        public decimal PreviousStock { get; private set; }
        public decimal NewStock { get; private set; }
        public string? Remarks { get; private set; }
        public Users Users { get; private set; }
        public int CreatedBy { get; private set; }
        public DateTime CreatedAt { get; private set; }

        protected StockMovements() { }

        public static StockMovements CrateMovement(int productId, int branchId, decimal quantity, string movementType, string referenceType, string referenceId, decimal previousStock, int createdBy, string? remarks = null, bool isStockin = true)
        {
            if (productId <= 0)
                throw new ArgumentException("Product ID must be greater than zero.", nameof(productId));

            if (branchId <= 0)
                throw new ArgumentException("Branch ID must be greater than zero.", nameof(branchId));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

            if (string.IsNullOrWhiteSpace(movementType))
                throw new ArgumentException("Movement type is required.", nameof(movementType));

            if (string.IsNullOrWhiteSpace(referenceType))
                throw new ArgumentException("Reference type is required.", nameof(referenceType));

            if (!string.IsNullOrWhiteSpace(referenceId))
                throw new ArgumentException("Reference ID invalid.", nameof(referenceId));

            if (createdBy <= 0)
                throw new ArgumentException("Created By must be greater than zero.", nameof(createdBy));

            if (previousStock < 0)
                throw new ArgumentException("Previous stock cannot be negative.", nameof(previousStock));

            decimal newStock = 0;

            if(isStockin)
            {
                newStock = previousStock + quantity;
            }
            else
            {
                newStock = previousStock - quantity;
            }

            return new StockMovements
            {
                ProductId = productId,
                BranchId = branchId,
                Quantity = quantity,
                MovementType = movementType.Trim(),
                ReferenceType = referenceType.Trim(),
                ReferenceId = referenceId,
                PreviousStock = previousStock,
                NewStock = newStock,
                CreatedBy = createdBy,
                CreatedAt = DateTime.UtcNow,
                Remarks = remarks?.Trim(),
            };
        }
    }
}
