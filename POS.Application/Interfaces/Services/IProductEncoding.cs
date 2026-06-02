using POS.Application.DTO.RequestDTO;
using POS.Application.DTO.ResponseDTO;
using POS.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.Interfaces.Services
{
    public interface IProductEncoding
    {
        Task<ResponseDTO<ProductEncodingResponseDTO>> AddProductAsync(ProductEncodingRequestDTO dto);
    }
}
