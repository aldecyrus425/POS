using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.DTO.ResponseDTO
{
    public class ProductUpdateResponseDTO
    {
        public string Barcode { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int ReorderLevel { get; set; }
        public bool IsTrackInventory { get; set; }
        public bool isActive { get; set; }
        public string ImageUrl { get; set; }
    }
}
