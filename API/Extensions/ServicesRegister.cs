using System;
using API.DataAccess.Implements;
using API.DataAccess.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;

namespace API.Extensions;

public static class  ServicesRegister
{
    public static void Register(this IServiceCollection service)
    {
        service.AddScoped<IUnitOfWork, UnitOfWork>();
        service.AddHttpContextAccessor();
        service.AddScoped<IProductService, ProductService>();
        service.AddScoped<IAuthService, AuthService>();
        service.AddScoped<ISalesService, SalesService>();
  
    }

}
