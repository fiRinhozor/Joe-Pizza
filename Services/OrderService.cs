using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pizzaboyz.Data;
using pizzaboyz.Models;
using Microsoft.EntityFrameworkCore;

namespace pizzaboyz.Services
{
  public class OrderService : IOrderService
  {
    private readonly ApplicationDbContext _context;
    public OrderService(ApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<Order[]> GetAllOrdersAsync(ApplicationUser user)
    {
      return await _context.Orders
      .Where(x => x.UserId == user.Id)
      .ToArrayAsync();
    }
    public async Task<bool> AddItemAsync(Order newOrder, ApplicationUser user)
    {
      var item = await _context.Orders
      .Where(x => x.Name == newOrder.Name && x.Size == newOrder.Size)
      .SingleOrDefaultAsync();
      if (item == null){
        newOrder.Id = Guid.NewGuid();
        _context.Orders.Add(newOrder);
        newOrder.UserId = user.Id;
        var saveResult = await _context.SaveChangesAsync();
        return saveResult == 1;
      }
      else {
        item.Quantity = item.Quantity + 1;
        var saveResult = await _context.SaveChangesAsync();
        return saveResult == 1; // One entity should have been updated
      }
    }

    public async Task<bool> UpdateOrderAsync(Guid id, ApplicationUser user)
    {
      var item = await _context.Orders
      .Where(x => x.Id == id && x.UserId == user.Id)
      .SingleOrDefaultAsync();
      if (item == null) return false;
      item.Quantity = item.Quantity + 1;
      var saveResult = await _context.SaveChangesAsync();
      return saveResult == 1; // One entity should have been updated
    }

    public async Task<bool> DeleteOrderAsync(Guid id, ApplicationUser user)
    {
      var item = await _context.Orders
      .Where(x => x.Id == id && x.UserId == user.Id)
      .SingleOrDefaultAsync();
      if (item == null) return false;
      _context.Orders.Remove(item);
      var saveResult = await _context.SaveChangesAsync();
      return saveResult == 1; // One entity should have been updated
    }
  }
}
