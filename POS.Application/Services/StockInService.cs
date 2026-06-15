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

        public StockInService(ISupplierRepository supplierRepo, IPurchaseOrdersRepository purchaseOrderRepo, IPurchaseOrderItemRepository purchaseOrderItemRepo, IProductRepository productRepo, IStockRepository stockRepo, IStockMovementRepository stockMovementRepo, IBranchRepository branchRepo)
        {
            _supplierRepo = supplierRepo;
            _purchaseOrderRepo = purchaseOrderRepo;
            _purchaseOrderItemRepo = purchaseOrderItemRepo;
            _productRepo = productRepo;
            _stockRepo = stockRepo;
            _stockMovementRepo = stockMovementRepo;
            _branchRepo = branchRepo;
        }

        public async Task<ResponseDTO<StockInResponseDTO>> StockInAsync(StockInRequestDTO dto)
        {
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

                var purchaseOrder = new PurchaseOrders(supplierId: dto.SupplierId, branchId: dto.BranchId, pONumber: GeneratePO(), status: "Received", createdBy: dto.UserId);
            }
        }

        private string GeneratePO()
        {
            var random = new Random();

            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";

            // Generate 4 random letters
            var letterPart = new string(Enumerable.Range(0, 4)
                .Select(_ => letters[random.Next(letters.Length)])
                .ToArray());

            // Generate 4 random digits
            var numberPart = new string(Enumerable.Range(0, 4)
                .Select(_ => numbers[random.Next(numbers.Length)])
                .ToArray());

            return $"{letterPart}-{numberPart}";
        }
    }
}
