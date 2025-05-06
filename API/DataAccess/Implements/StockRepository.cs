using System;
using API.DataAccess.Interfaces;
using API.Models;

namespace API.DataAccess.Implements;

public class StockRepository:GenericRepository<Stock>,IStockRepository
{
    public StockRepository(InventoryDbContext _context):base(_context){}

}
