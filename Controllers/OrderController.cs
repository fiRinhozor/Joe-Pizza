using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pizzaboyz.Services;
using pizzaboyz.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pizzaboyz.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
      private readonly IOrderService _orderService;
      private readonly UserManager<ApplicationUser> _userManager;

      public OrderController(IOrderService orderService, UserManager<ApplicationUser> userManager)
      {
        _orderService = orderService;
        _userManager = userManager;
      }

      public async Task<IActionResult> Index()
      {
        var currentUser = await _userManager.GetUserAsync(User);
        if (currentUser == null) return Challenge();
        var orders = await _orderService.GetAllOrdersAsync(currentUser);

        var model = new OrderViewModel()
        {
          Orders = orders
        };

        return View(model);
      }


      [ValidateAntiForgeryToken]
      public async Task<IActionResult> AddOrder(Order newOrder)
      {
        if (!ModelState.IsValid)
        {
          return RedirectToAction("Index", "Home");
        }

        var currentUser = await _userManager.GetUserAsync(User);
        if (currentUser == null) return Challenge();

        var successful = await _orderService.AddItemAsync(newOrder, currentUser);
        if (!successful)
        {
          return BadRequest("Could not add item.");
        }
        ViewBag.SuccessMessage = "<h1>Success!</h1>";
        return RedirectToAction("Index", "Home", ViewBag);
      }


      [ValidateAntiForgeryToken]
      public async Task<IActionResult> UpdateOrder(Guid id)
      {
        if (id == Guid.Empty)
        {
          return RedirectToAction("Index");
        }

        var currentUser = await _userManager.GetUserAsync(User);
        if (currentUser == null) return Challenge();

        var successful = await _orderService.UpdateOrderAsync(id, currentUser);
        if (!successful)
        {
          return BadRequest("Could not Update.");
        }
        return RedirectToAction("Index");
      }

      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteOrder(Guid id)
      {
        if (id == Guid.Empty)
        {
          return RedirectToAction("Index");
        }

        var currentUser = await _userManager.GetUserAsync(User);
        if (currentUser == null) return Challenge();

        var successful = await _orderService.DeleteOrderAsync(id, currentUser);
        if (!successful)
        {
          return BadRequest("Could not Delete.");
        }
        return RedirectToAction("Index");
      }


      public IActionResult OrderCompleted()
      {
          return View();
      }
    }
}
