using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task AddProduct(Products product);
    }
}
