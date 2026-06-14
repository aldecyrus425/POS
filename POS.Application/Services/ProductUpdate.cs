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
    public class ProductUpdate : IProductUpdate
    {
        private readonly IProductRepository _productRepository;
        private readonly IImageStorageService _imageStorageService;

        public ProductUpdate(IProductRepository productRepository, IImageStorageService imageStorageService)
        {
            _productRepository = productRepository;
            _imageStorageService = imageStorageService;
        }

        public async Task<ResponseDTO<ProductUpdateDetailsResponseDTO>> UpdateProductAsync(ProductUpdateDetailsRequestDTO dto)
        {
            try
            {
                string? imageUrl = null;
                if (dto.Image != null)
                {
                    imageUrl = await _imageStorageService.UploadImageAsync(dto.Image);
                }
                var product = await _productRepository.GetProductByIDAsync(dto.ProductId);
                if (product == null)
                {
                    return new ResponseDTO<ProductUpdateDetailsResponseDTO>
                    {
                        IsSuccess = false,
                        Message = "Product not found"
                    };
                }

                product.UpdateProduct();
                await _productRepository.SaveChangesAsync();

                return new ResponseDTO<ProductUpdateDetailsResponseDTO>
                {
                    IsSuccess = true,
                    Message = "Product updated successfully."

                };
            }
            catch (ArgumentException ex)
            {
                return new ResponseDTO<ProductUpdateDetailsResponseDTO>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<ProductUpdateDetailsResponseDTO>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
