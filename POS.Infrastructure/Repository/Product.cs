using POS.Application.Interfaces.Repositories;
using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Infrastructure.Repository
{
    public class Product : IProductRepository
    {
        public Task<Products> CreateProduct(Products products)
        {
            throw new NotImplementedException();
        }
    }
}
