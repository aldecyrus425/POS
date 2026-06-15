using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.DTO.RequestDTO
{
    public class StockInRequestDTO
    {
        public int SupplierId { get; set; }
        public int BranchId { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime DateReceived { get; set; }
        public int UserId { get; set; }
        public List<StockInItemRequestDTO> Items { get; set; }  
    }
}
