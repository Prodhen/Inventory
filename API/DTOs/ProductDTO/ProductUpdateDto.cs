using System;

namespace API.DTOs.ProductDTO;

public class ProductUpdateDto
{
    public int Id { get; set;}
     public required string  ProductName { get; set; }


    public string? SkuCode { get; set; }


    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public string? Description { get; set; }

}
