using POS.Application.DTO;
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
    public class ProductEncoding : IProductEncoding
    {
        private readonly IProductRepository _productRepository;
        private readonly IImageStorageService _imageStorageService;

        public ProductEncoding(IProductRepository productRepository, IImageStorageService imageStorageService)
        {
            _productRepository = productRepository;
            _imageStorageService = imageStorageService;
        }

        public async Task<ResponseDTO<ProductEncodingResponseDTO>> AddProductAsync(ProductEncodingRequestDTO dto)
        {
            try
            {

                var imageLocation = await _imageStorageService.UploadImageAsync(dto.Image);
                var product = new Products(dto.Barcode, dto.SKU, dto.ProductName, dto.Description, dto.CategoryId, dto.UnitId, dto.CostPrice, dto.SellingPrice, dto.ReorderLevel, dto.IsTrackInventory, dto.isActive, imageLocation);
                await _productRepository.AddProductAsync(product);
                await _productRepository.SaveChangesAsync();
                return new ResponseDTO<ProductEncodingResponseDTO>
                {
                    IsSuccess = true,
                    Message = "Product added successfully",
                };
            }
            catch (ArgumentNullException ex)
            {
                return new ResponseDTO<ProductEncodingResponseDTO>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
            catch (ArgumentException ex)
            {
                return new ResponseDTO<ProductEncodingResponseDTO>
                {
                    IsSuccess = false,
                    Message = $"Invalid input: {ex.Message}"
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<ProductEncodingResponseDTO>
                {
                    IsSuccess = false,
                    Message = $"An error occurred while adding the product: {ex.Message}"
                };
            }
            
        }
    }
}
