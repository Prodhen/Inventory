using System;
using System.Net.Http.Headers;
using API.DTOs;
using API.DTOs.Common;
using API.DTOs.ProductDTO;

namespace API.Services.Interfaces;

public interface IProductService
{
    Task<ResponseDto> GetAllProducts();
    Task<ResponseDto> GetProductById(int id);
    Task<ResponseDto> AddProduct(ProductAddDto productAddDto);
    Task<ResponseDto> UpdateProduct(ProductUpdateDto todoItemDto);
    Task<ResponseDto> DeleteProduct(int id);

}
