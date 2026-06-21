using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.DTO.ResponseDTO
{
    public class StockOutResponseDTO
    {
        public int SaleId { get; set; }
        public string ReferenceNo { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime SoldAt { get; set; }
        public int TotalItems { get; set; }
        public string Status { get; set; }
    }
}
