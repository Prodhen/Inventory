using System;

namespace API.DTOs.SalesDTO;

public class SaleItemDto
{   
    public int ProductId { get; set; } // Foreign key to Product
    public int QuantitySold { get; set; } // Quantity sold of the product

}
