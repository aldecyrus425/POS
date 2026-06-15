using POS.Application.DTO.ResponseDTO;
using POS.Application.Interfaces.Repository;
using POS.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.Services
{
    public class DeleteProductService : IDeleteProduct
    {
        private readonly IProductRepository _productRepo;

        public DeleteProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<ResponseDTO<bool>> DeleteProduct(int productId)
        {
            try
            {
                var product = await _productRepo.GetProductByIDWithDetailsAsync(productId);
                if(product == null)
                {
                    return new ResponseDTO<bool>
                    {
                        IsSuccess = false,,
                        Message = "Product not found."
                    };
                }

                product.DeleteProduct();
                await _productRepo.SaveChangesAsync();

                return new ResponseDTO<bool>
                {
                    IsSuccess = true,
                    Message = "Product Deleted Successfully."
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
