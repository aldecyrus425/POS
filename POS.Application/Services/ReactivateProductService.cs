using POS.Application.DTO.ResponseDTO;
using POS.Application.Interfaces.Repository;
using POS.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.Services
{
    public class ReactivateProductService : IReactivateProductService
    {
        private readonly IProductRepository _repository;

        public ReactivateProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseDTO<bool>> ReactivateProductAsync(int productId)
        {
            try
            {
                var product = await _repository.GetProductByIDWithDetailsAsync(productId);
                if (product == null)
                {
                    return new ResponseDTO<bool>
                    {
                        IsSuccess = false,
                        Message = "Product not found."
                    };
                }

                product.ReactivateProduct();
                await _repository.SaveChangesAsync();

                return new ResponseDTO<bool>
                {
                    IsSuccess = true,
                    Message = "Product reactivation successfully."
                };

            }
            catch (Exception ex)
            {
                return new ResponseDTO<bool>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }

        }
    }
}


