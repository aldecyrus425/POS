using POS.Application.DTO.RequestDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.Interfaces.Services
{
    public interface IProductScanningService
    {
        Task<IProductScanningService> GetProductScanningAsync(ProductScanningRequestDTO dto);
    }
}
