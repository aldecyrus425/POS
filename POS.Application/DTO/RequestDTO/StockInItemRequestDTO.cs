using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.DTO.RequestDTO
{
    public class StockInItemRequestDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal CostPrice { get; set; }
    }
}
