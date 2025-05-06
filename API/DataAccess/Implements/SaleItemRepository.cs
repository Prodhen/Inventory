using System;
using API.DataAccess.Interfaces;
using API.Models;

namespace API.DataAccess.Implements;

 public class SaleItemRepository : GenericRepository<SaleItem>, ISaleItemRepository
  {
        public SaleItemRepository(InventoryDbContext _context) : base(_context) { }

  }
