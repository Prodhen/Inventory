using System;
using System.Reflection;
using API.DataAccess.Interfaces;
using API.DTOs;
using API.DTOs.Common;
using API.DTOs.ProductDTO;
using API.Helper;
using API.Models;
using API.Services.Interfaces;
using MapsterMapper;

namespace API.Services.Implements;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
     private readonly IMapper _mapper;
    public ProductService(IUnitOfWork unitOfWork,IMapper mapper){
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ResponseDto> GetAllProducts()
    {
        var products = await _unitOfWork.Products
            .GetAll(p => !p.IsDeleted);

        var productDtos = _mapper.Map<List<ProductDto>>(products);

        return ResponseHelper.Success(data: productDtos);
    }

    public async Task<ResponseDto> GetProductById(int id)
    {
        var product = await _unitOfWork.Products.GetById(id);

        if (product == null)
            return ResponseHelper.ValidationError("Product not found");

        var productDto = _mapper.Map<ProductDto>(product);
        return ResponseHelper.Success(data: productDto);
    }

    public async Task<ResponseDto> AddProduct(ProductAddDto productAddDto)
    {
        var product = _mapper.Map<Product>(productAddDto);
        product.CreatedAt=DateTime.Now;
        product.CreatedBy=_unitOfWork.LoggedInUserId();
        product.IsDeleted=false;

         _unitOfWork.Products.Add(product);
        await _unitOfWork.SaveAsync();

        return ResponseHelper.Created(data: product);
    }

    public async Task<ResponseDto> UpdateProduct(ProductUpdateDto productUpdateDto)
    {
        var product = await _unitOfWork.Products.GetById(productUpdateDto.Id);

        if (product == null)
            return ResponseHelper.ValidationError("Product not found");

        _mapper.Map(productUpdateDto, product);
        
        product.UpdatedAt = DateTime.Now;
        product.UpdatedBy=_unitOfWork.LoggedInUserId();
        _unitOfWork.Products.Update(product);
        await _unitOfWork.SaveAsync();

        return ResponseHelper.Updated(data: product);
    }

    public async Task<ResponseDto> DeleteProduct(int id)
    {
        var product = await _unitOfWork.Products.GetById(id);

        if (product == null)
            return ResponseHelper.ValidationError("Product not found");

        product.IsDeleted = true;
        _unitOfWork.Products.Update(product);
        await _unitOfWork.SaveAsync();

        return ResponseHelper.Deleted();
    }
}
