using System;
using API.DTOs.Common;
using API.DTOs.SalesDTO;

namespace API.Services.Interfaces;

public interface ISalesService
{
    Task<ResponseDto> ProcessSaleAsync(List<SaleItemDto> saleItemsDto);

}
