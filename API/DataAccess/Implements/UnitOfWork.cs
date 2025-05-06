using System;
using System.Security.Claims;
using API.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace API.DataAccess.Implements;

public class UnitOfWork:IUnitOfWork
{
     private readonly InventoryDbContext _dbContext;
     private readonly IHttpContextAccessor _httpContext;
      private IDbContextTransaction? _transaction;

    public UnitOfWork(InventoryDbContext dataContext, IHttpContextAccessor httpContext)
    {
        this._dbContext = dataContext;
        this._httpContext = httpContext;
        Products = new ProductRepository(_dbContext);
        Users = new UserRepository(_dbContext);
        SaleItems=new SaleItemRepository(_dbContext);
        SaleOrders=new SaleOrderRepository(_dbContext);
        Stocks=new StockRepository(_dbContext);
    }
    public IProductRepository Products { get; set; }
    
    public IUserRepository Users { get; set; }

    public ISaleItemRepository SaleItems { get; set; }
    public ISaleOrderRepository SaleOrders { get; set; }
    public IStockRepository Stocks { get; set; }
    




    public int LoggedInUserId()
    {
        var loggedInUserId = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(loggedInUserId)) throw new UnauthorizedAccessException();
        return Convert.ToInt32(loggedInUserId);
    }



    public int Save()
    {
        return _dbContext.SaveChanges();
    }

    public Task<int> SaveAsync()
    {
        return _dbContext.SaveChangesAsync();
    }

     public async Task BeginTransactionAsync()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _transaction.CommitAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _transaction.RollbackAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
        _transaction?.Dispose();
    }


}
