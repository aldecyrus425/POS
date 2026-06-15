using POS.Application.DTO.RequestDTO;
using POS.Application.DTO.ResponseDTO;
using POS.Application.Interfaces.Repository;
using POS.Application.Interfaces.Services;
using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.Services
{
    public class ProductUpdateService : IProductUpdate
    {
        private readonly IProductRepository _productRepository;
        private readonly IImageStorageService _imageStorageService;

        public ProductUpdateService(IProductRepository productRepository, IImageStorageService imageStorageService)
        {
            _productRepository = productRepository;
            _imageStorageService = imageStorageService;
        }

        public async Task<ResponseDTO<ProductUpdateResponseDTO>> UpdateProductAsync(ProductUpdateRequestDTO dto)
        {
            try
            {
                string? imageUrl = null;
                if (dto.Image != null)
                {
                    imageUrl = await _imageStorageService.UploadImageAsync(dto.Image);
                }
                var product = await _productRepository.GetProductByIDWithDetailsAsync(dto.ProductId);
                if (product == null)
                {
                    return new ResponseDTO<ProductUpdateResponseDTO>
                    {
                        IsSuccess = false,
                        Message = "Product not found"
                    };
                }

                product.UpdateProduct(dto.Barcode, dto.SKU, dto.ProductName, dto.Description, dto.CategoryId, dto.UnitId, dto.CostPrice, dto.SellingPrice, dto.ReorderLevel, dto.IsTrackInventory, dto.isActive, imageUrl);
                await _productRepository.SaveChangesAsync();


                return new ResponseDTO<ProductUpdateResponseDTO>
                {
                    IsSuccess = true,
                    Message = "Product updated successfully.",
                    Data = new ProductUpdateResponseDTO
                    {
                        Barcode = product.Barcode,
                        SKU = product.SKU,
                        ProductName = product.Name,
                        Description = product.Description,
                        CategoryId = product.CategoryId,
                        CategoryName = product.Categories.Name,
                        UnitId = product.UnitId,
                        UnitName = product.Units.UnitName,
                        CostPrice = product.CostPrice,
                        SellingPrice = product.SellingPrice,
                        ReorderLevel = product.ReorderLevel,
                        IsTrackInventory = product.IsTrackInventory,
                        isActive = product.IsActive,
                        ImageUrl = product.ImageUrl
                    }

                };
            }
            catch (ArgumentException ex)
            {
                return new ResponseDTO<ProductUpdateResponseDTO>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<ProductUpdateResponseDTO>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
