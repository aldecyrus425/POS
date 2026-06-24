using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<Products?> GetProductByIDWithDetailsAsync(int id);
        Task<Products?> GetProductByBarCodeWithDetailsAsync(string barCode);
        Task AddProductAsync(Products products);
        Task SaveChangesAsync();
    }
}
