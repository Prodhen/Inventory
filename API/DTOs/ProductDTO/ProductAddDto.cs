using System;
using API.Models;
using FluentValidation;

namespace API.DTOs;

public class ProductAddDto
{
     public required string  ProductName { get; set; }

    public string? SkuCode { get; set; }


    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public string? Description { get; set; }
   

}
public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.ProductName)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(200);

        RuleFor(p => p.SkuCode)
            .MaximumLength(100).When(p => !string.IsNullOrWhiteSpace(p.SkuCode));

        RuleFor(p => p.Price)
            .GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to 0.");

        RuleFor(p => p.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Stock quantity must be non-negative.");

        
    }
}
