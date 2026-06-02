using POS.Application.DTO.RequestDTO;
using POS.Application.DTO.ResponseDTO;
using POS.Application.Interfaces.Repository;
using POS.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.Services
{
    public class ProductEncoding : IProductEncoding
    {
        private readonly IProductRepository _productRepository;

        public ProductEncoding(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<ResponseDTO<ProductEncodingResponseDTO>> AddProductAsync(ProductEncodingRequestDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
