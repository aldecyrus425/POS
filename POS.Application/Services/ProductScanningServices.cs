using POS.Application.DTO.RequestDTO;
using POS.Application.DTO.ResponseDTO;
using POS.Application.Interfaces.Repository;
using POS.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.Services
{
    public class ProductScanningServices : IProductScanningService
    {
        private readonly IProductRepository _productRepo;
        private readonly IStockRepository _stockRepo;

        public ProductScanningServices(IProductRepository productRepo, IStockRepository stockRepo)
        {
            _productRepo = productRepo;
            _stockRepo = stockRepo;
        }

        public async Task<ResponseDTO<ProductScanningResponseDTO>> GetProductScanningAsync(ProductScanningRequestDTO dto)
        {
            try
            {
                var product = await _productRepo.GetProductByBarCodeWithDetailsAsync(dto.BarcodeId);
                if (product == null)
                    return new ResponseDTO<ProductScanningResponseDTO>
                    {
                        IsSuccess = false,
                        Message = "Product not found."
                    };

                var stock = await _stockRepo.GetByProductAndBranchAsync(product.ProductId, dto.BranchId);
                if (stock == null)
                    return new ResponseDTO<ProductScanningResponseDTO>
                    {
                        IsSuccess = false,
                        Message = "Stock not Found"
                    };

                return new ResponseDTO<ProductScanningResponseDTO>
                {
                    IsSuccess = true,
                    Message = "Product informations",
                    Data = new ProductScanningResponseDTO
                    {
                        PoductName = product.Name,
                        SKU = product.SKU,
                        CategoryName = product.Categories.Name,
                        UnitName = product.Units.UnitName,
                        SellingPrice = product.SellingPrice,
                        ImageUrl = product.ImageUrl,
                        AvailableQuantity = stock.QuantityOnHand
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<ProductScanningResponseDTO>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
