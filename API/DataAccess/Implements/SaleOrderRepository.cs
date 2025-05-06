using System;
using API.DataAccess.Interfaces;
using API.Models;

namespace API.DataAccess.Implements;

public class SaleOrderRepository:GenericRepository<SaleOrder>, ISaleOrderRepository
{
    public SaleOrderRepository(InventoryDbContext _context) : base(_context) { }

}
