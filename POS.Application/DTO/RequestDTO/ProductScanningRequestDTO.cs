using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.DTO.RequestDTO
{
    public class ProductScanningRequestDTO
    {
        public string BarcodeId { get; set; }
        public int BranchId { get; set; }
    }
}
