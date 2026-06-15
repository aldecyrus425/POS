using POS.Application.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.Interfaces.Services
{
    public interface IDeleteProduct
    {
        Task<ResponseDTO<bool>> DeleteProduct(int productId);
    }
}
