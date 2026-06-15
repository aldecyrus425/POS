using POS.Application.DTO.RequestDTO;
using POS.Application.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.Interfaces.Services
{
    public interface IProductUpdate
    {
        Task<ResponseDTO<ProductUpdateResponseDTO>> UpdateProductAsync(ProductUpdateRequestDTO dto);
    }
}
