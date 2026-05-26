using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Products> CreateProduct(Products products);
    }
}
