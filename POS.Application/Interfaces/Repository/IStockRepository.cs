using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.Interfaces.Repository
{
    public interface IStockRepository
    {
        Task AddStocksAsync(Stocks stock);

        Task<Stocks> GetByProductAndBranchAsync(int productId, int branchId); 

    }
}
