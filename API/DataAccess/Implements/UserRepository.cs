using System;
using API.DataAccess.Interfaces;
using API.Models;

namespace API.DataAccess.Implements;

public class UserRepository: GenericRepository<User>, IUserRepository
{
  public UserRepository(InventoryDbContext _context) : base(_context) { }

}
