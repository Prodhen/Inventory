using System;

namespace API.DTOs.ProductDTO;

public class ProductDto
{
     public int Id { get; set; }

    public required string  ProductName { get; set; }


    public string? SkuCode { get; set; }


    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public string? Description { get; set; }


    public bool IsDeleted { get; set; } = false;

    public int CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; } 

    public DateTime? UpdatedAt { get; set; }

}
