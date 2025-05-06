using System;
using API.DataAccess.Interfaces;
using API.DTOs.Common;
using API.DTOs.SalesDTO;
using API.Helper;
using API.Models;
using API.Services.Interfaces;

namespace API.Services.Implements;

public class SalesService:ISalesService
{
    private readonly IUnitOfWork _unitOfWork;
    public SalesService(IUnitOfWork unitOfWork){
        _unitOfWork = unitOfWork;

    }


public async Task<ResponseDto> ProcessSaleAsync(List<SaleItemDto> saleItemsDto)
{
    await _unitOfWork.BeginTransactionAsync(); // Start transaction

    try
    {
        var saleOrder = new SaleOrder
        {
            SaleDate = DateTime.UtcNow,
            SaleItems = new List<SaleItem>()
        };

        foreach (var itemDto in saleItemsDto)
        {
            var product = await _unitOfWork.Products.GetById(itemDto.ProductId);

            if (product == null || product.IsDeleted)
                return ResponseHelper.ValidationError($"Product with ID {itemDto.ProductId} not found or deleted.");

            if (product.StockQuantity < itemDto.QuantitySold)
                return ResponseHelper.ValidationError($"Not enough stock for {product.ProductName}.");
            int userId=_unitOfWork.LoggedInUserId();

            product.StockQuantity -= itemDto.QuantitySold;
            product.UpdatedBy=userId;
            product.UpdatedAt=DateTime.UtcNow;

            var saleItem = new SaleItem
            {
                ProductId = itemDto.ProductId,
                QuantitySold = itemDto.QuantitySold,
                TotalPrice = product.Price * itemDto.QuantitySold,
                CreatedAt=DateTime.UtcNow,
                CreatedBy=userId,

            };

      

            saleOrder.SaleItems.Add(saleItem);
            saleOrder.CreatedBy=userId;
            saleOrder.CreatedAt=DateTime.UtcNow;
            saleOrder.Code = $"SE-{product.SkuCode}-{DateTime.UtcNow:yyyyMMddHHmmssfff}";


            var stock = new Stock
            {
                ProductId = itemDto.ProductId,
                Quantity = itemDto.QuantitySold,
                Reference=      saleOrder.Code,
                Type = "SALE",
                Remarks = $"Sale Order for Product {product.SkuCode}",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = userId
            };

            _unitOfWork.Stocks.Add(stock);
            
        
        }

        _unitOfWork.SaleOrders.Add(saleOrder);
        await _unitOfWork.SaveAsync();

        await _unitOfWork.CommitTransactionAsync();
        return ResponseHelper.Success("Sale processed successfully.");
    }
    catch (Exception ex)
    {
        await _unitOfWork.RollbackTransactionAsync();
        return ResponseHelper.Failure($"Error: {ex.Message}");
    }
}

}
