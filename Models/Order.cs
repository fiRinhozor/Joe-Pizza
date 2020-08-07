using System;
namespace pizzaboyz.Models
{
    public class Order
    {
      public Guid Id { get; set; }
      public string UserId { get; set; }
      public string Name {get; set;}
      public string Size {get; set;}
      public int Quantity {get; set;}
      public double Price {get; set;}
    }
}
