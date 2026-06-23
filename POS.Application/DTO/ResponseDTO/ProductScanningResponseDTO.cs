using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.DTO.ResponseDTO
{
    public class ProductScanningResponseDTO
    {
        public string PoductName { get; set; }
        public string SKU {  get; set; }
        public string CategoryName { get; set; }
        public string UnitName { get; set; }
        public decimal SellingPrice { get; set; }
        public string ImageUrl { get; set; }
        public decimal AvailableQuantity { get; set; }  

    }
}
