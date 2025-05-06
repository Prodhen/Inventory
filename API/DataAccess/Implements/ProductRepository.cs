using System;
using API.DataAccess.Interfaces;
using API.Models;

namespace API.DataAccess.Implements;

  public class ProductRepository : GenericRepository<Product>, IProductRepository
  {
        public ProductRepository(InventoryDbContext _context) : base(_context) { }

  }