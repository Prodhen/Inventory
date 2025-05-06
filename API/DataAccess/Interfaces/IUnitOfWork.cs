using System;

namespace API.DataAccess.Interfaces;

public interface IUnitOfWork:IDisposable
{
    int Save();
    Task<int> SaveAsync();
    int LoggedInUserId();
    IProductRepository Products { get; set; }
    IUserRepository Users { get; set; }
    ISaleItemRepository SaleItems { get; set; }
    ISaleOrderRepository SaleOrders { get; set; }
    IStockRepository Stocks {get;set;}
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();


}
