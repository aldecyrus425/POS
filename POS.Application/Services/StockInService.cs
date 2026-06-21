using POS.Application.DTO.RequestDTO;
using POS.Application.DTO.ResponseDTO;
using POS.Application.Interfaces.Repository;
using POS.Application.Interfaces.Services;
using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.Services
{
    public class StockInService : IStockInService
    {
        private readonly ISupplierRepository _supplierRepo;
        private readonly IPurchaseOrdersRepository _purchaseOrderRepo;
        private readonly IPurchaseOrderItemRepository _purchaseOrderItemRepo;
        private readonly IProductRepository _productRepo;
        private readonly IStockRepository _stockRepo;
        private readonly IStockMovementRepository _stockMovementRepo;
        private readonly IBranchRepository _branchRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICodeGenerator _codegen;

        public StockInService(ISupplierRepository supplierRepo, IPurchaseOrdersRepository purchaseOrderRepo, IPurchaseOrderItemRepository purchaseOrderItemRepo, IProductRepository productRepo, IStockRepository stockRepo, IStockMovementRepository stockMovementRepo, IBranchRepository branchRepo, IUnitOfWork unitOfWork, ICodeGenerator codeGenerator)
        {
            _supplierRepo = supplierRepo;
            _purchaseOrderRepo = purchaseOrderRepo;
            _purchaseOrderItemRepo = purchaseOrderItemRepo;
            _productRepo = productRepo;
            _stockRepo = stockRepo;
            _stockMovementRepo = stockMovementRepo;
            _branchRepo = branchRepo;
            _unitOfWork = unitOfWork;
            _codegen = codeGenerator;
        }

        public async Task<ResponseDTO<StockInResponseDTO>> StockInAsync(StockInRequestDTO dto)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var supplier = await _supplierRepo.GetSupplierAsync(dto.SupplierId);
                if (supplier == null)
                {
                    return new ResponseDTO<StockInResponseDTO>
                    {
                        IsSuccess = false,
                        Message = "Supplier not found."
                    };
                }

                var purchaseOrder = new PurchaseOrders(supplierId: dto.SupplierId, branchId: dto.BranchId, pONumber: _codegen.GenerateCode(), status: "Received", createdBy: dto.UserId);
                await _purchaseOrderRepo.CreatePurchaseOrderAsync(purchaseOrder);

                foreach (var item in dto.Items)
                {
                    var product = await _productRepo.GetProductByIDWithDetailsAsync(item.ProductId);
                    if (product == null)
                        throw new Exception("Product not found.");

                    var stock = await _stockRepo.GetByProductAndBranchAsync(item.ProductId, dto.BranchId);

                    stock.ReceiveStock(item.Quantity);

                    var purchaseOrderItem = new PurchaseOrderItems(purchaseOrderId: purchaseOrder.PurchaseOrderID, productId: item.ProductId, quantity: item.Quantity, costPrice: product.CostPrice);
                    await _purchaseOrderItemRepo.CreatePurchaseOrderItemAsync(purchaseOrderItem);

                    var stockMovement = StockMovements.CrateMovement(productId: item.ProductId, branchId: dto.BranchId, quantity: item.Quantity, movementType: "StockIn", referenceType: dto.ReferenceType, referenceId: purchaseOrder.PurchaseOrderID, previousStock: stock.QuantityOnHand, createdBy: dto.UserId);
                    await _stockMovementRepo.CreateStockMovementAsync(stockMovement);
                }

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                return new ResponseDTO<StockInResponseDTO>
                {
                    IsSuccess = true,
                    Message = "Stock-in successful.",
                    Data = new StockInResponseDTO
                    {
                        PurchaseOrderID = purchaseOrder.PurchaseOrderID,
                        ReferenceNo = purchaseOrder.PONumber,
                        DateReceived = purchaseOrder.ReceivedAt ?? DateTime.Now,
                        TotalItems = dto.Items.Count,
                        TotalQuantity = dto.Items.Sum(i => i.Quantity),
                        Status = purchaseOrder.Status
                    }
                };
            }
            catch (ArgumentException ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new ResponseDTO<StockInResponseDTO>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new ResponseDTO<StockInResponseDTO>
                {
                    IsSuccess = false,
                    Message = $"Stock-in failed: {ex.Message}"
                };
            }
        }

        
    }
}
