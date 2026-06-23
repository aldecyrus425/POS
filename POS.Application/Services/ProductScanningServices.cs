using POS.Application.DTO.RequestDTO;
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

        public Task<IProductScanningService> GetProductScanningAsync(ProductScanningRequestDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
