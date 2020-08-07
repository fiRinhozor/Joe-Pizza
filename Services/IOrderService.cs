using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pizzaboyz.Models;

namespace pizzaboyz.Services
{
  public interface IOrderService
  {
    Task<Order[]> GetAllOrdersAsync(ApplicationUser user);

    Task<bool> AddItemAsync(Order newOrder, ApplicationUser user);
    Task<bool> UpdateOrderAsync(Guid id, ApplicationUser user);
    Task<bool> DeleteOrderAsync(Guid id, ApplicationUser user);
  }
}
