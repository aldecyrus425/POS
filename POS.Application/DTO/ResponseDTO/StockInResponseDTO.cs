using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.DTO.ResponseDTO
{
    public class StockInResponseDTO
    {
        public int PurchaseOrderID { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime DateReceived { get; set; }
        public int TotalItems { get; set; }
        public int TotalQuantity { get; set; }
        public string Status { get; set; }
    }
}
