using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.DTO.RequestDTO
{
    public class StockOutRequestDTO
    {
        public int BranchId { get; set; }
        public int CustomerId { get; set; } // optional (walk-in = null)
        public int CreatedBy { get; set; }
        public string? ReferenceNo { get; set; }

        public decimal TaxRate { get; set; }
        public string Notes { get; set; } = "";

        public List<StockOutItemRequestDTO> Items { get; set; }
    }

    public class StockOutItemRequestDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal discountAmount { get; set; } = 0;
    }
}
