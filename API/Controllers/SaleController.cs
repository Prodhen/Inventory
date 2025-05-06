using API.DTOs.SalesDTO;
using API.Services.Implements;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class SaleController : BaseController
    {
        private readonly ISalesService _saleService;

        public SaleController(ISalesService saleService){
            _saleService = saleService;
        }
        [HttpPost("SaleProduct")]
        public async Task<ActionResult> SaleProduct(List<SaleItemDto> saleItems)
        {
            var response = await _saleService.ProcessSaleAsync(saleItems);
            return StatusCode(response.StatusCode, response);
        }

    }
}
