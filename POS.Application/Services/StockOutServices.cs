using POS.Application.DTO.RequestDTO;
using POS.Application.DTO.ResponseDTO;
using POS.Application.Interfaces.Repository;
using POS.Application.Interfaces.Services;
using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace POS.Application.Services
{
    public class StockOutServices : IStockOutService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IStockMovementRepository _stockMovementRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICodeGenerator _codegen;
        private readonly IUnitOfWork _unitOfWork;

        public StockOutServices(ISaleRepository saleRepository, IStockRepository stockRepository, IStockMovementRepository stockMovementRepository, IProductRepository productRepository, ICodeGenerator codeGenerator, IUnitOfWork unitOfWork)
        {
            _saleRepository = saleRepository;
            _stockRepository = stockRepository;
            _stockMovementRepository = stockMovementRepository;
            _productRepository = productRepository;
            _codegen = codeGenerator;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDTO<StockOutResponseDTO>> StockOutAsync(StockOutRequestDTO dto)
        {
            _unitOfWork.BeginTransactionAsync();
            try
            {
                decimal Subtotal = 0;
                decimal Discounted = 0;

                foreach (var item in dto.Items)
                {
                    Subtotal = item.SellingPrice * item.Quantity;
                    Discounted += item.discountAmount;
                }

                var sale = Sales.CreateSale(saleNumber: _codegen.GenerateCode(), branchId: dto.BranchId, customerId: dto.CustomerId, cashierId: dto.CreatedBy, subtotal: Subtotal, discountAmount: Discounted, taxRate: dto.TaxRate, notes: dto.Notes);
                await _saleRepository.CreatSaleAsync(sale);

                await _unitOfWork.SaveChangesAsync();


                foreach (var item in dto.Items)
                {
                    var stock = await _stockRepository.GetByProductAndBranchAsync(item.ProductId, dto.BranchId);

                    var stockMovement = StockMovements.CrateMovement(productId: item.ProductId, branchId: dto.BranchId, quantity: item.Quantity, movementType: "Sale", referenceType: "Sale", referenceId: sale.SaleNumber, previousStock: stock.QuantityOnHand, createdBy: dto.CreatedBy, isStockin: false);
                    
                    stock.StockOut(item.Quantity);

                    

                    await _stockMovementRepository.CreateStockMovementAsync(stockMovement);
                }

                

                return new ResponseDTO<StockOutResponseDTO>
                {
                    IsSuccess = true,
                    Message = "Purchase successful."
                };

                _unitOfWork.SaveChangesAsync();
                _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransactionAsync();
                return new ResponseDTO<StockOutResponseDTO>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };

            }
        }
    }
}

